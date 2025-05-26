using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Encodings.Web;

class Program
{
    static void Main(string[] args)
    {
        Scripture currentScripture = null;
        string[] referencesSaveLines;
        string[] referencesLines;

        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine();
        Console.WriteLine("1 - Choose a verse from your saved list");
        Console.WriteLine("2 - Browse all available verses and choose one");
        Console.WriteLine("3 - Let the system choose a random verse for you");
        Console.WriteLine();
        Console.Write("Enter the number of your choice: ");

        int _choose = int.Parse(Console.ReadLine());

        switch (_choose)
        {
            case 1:
                referencesSaveLines = LoadFromFile("./Files/referencesSaved.csv");
                if (referencesSaveLines == null || referencesSaveLines.Length == 0)
                {
                    Console.WriteLine("No data loaded.");
                }
                else
                {
                    ShowReferencesLines(referencesSaveLines);
                    Console.WriteLine();
                    Console.WriteLine("Enter with references's id: ");
                    int id_Ref = int.Parse(Console.ReadLine());
                    Reference referenceSave = GetReferenceById(id_Ref, referencesSaveLines);

                    string[] textLines_1 = LoadFromFile("./Files/texts.csv");
                    if (textLines_1 == null || textLines_1.Length == 0)
                    {
                        Console.WriteLine("No data loaded.");
                    }
                    else
                    {
                        string text = GetText(id_Ref, textLines_1);
                        Scripture scripture_1 = new Scripture(referenceSave, text);
                        currentScripture = scripture_1;
                        RunGame(scripture_1);
                        AskToSave(currentScripture);
                    }
                }
                break;

            case 2:
                referencesLines = LoadFromFile("./Files/references.csv");
                if (referencesLines == null || referencesLines.Length == 0)
                {
                    Console.WriteLine("No data loaded.");
                }
                else
                {
                    ShowReferencesLines(referencesLines);
                    Console.WriteLine();
                    Console.WriteLine("Enter with references's id: ");
                    int id_Ref = int.Parse(Console.ReadLine());
                    Reference referenceChoose = GetReferenceById(id_Ref, referencesLines);
                    string[] textLines_2 = LoadFromFile("./Files/texts.csv");
                    if (textLines_2 == null || textLines_2.Length == 0)
                    {
                        Console.WriteLine("No data loaded.");
                    }
                    else
                    {

                        string text = GetText(id_Ref, textLines_2);
                        Scripture scripture_2 = new Scripture(referenceChoose, text);
                        currentScripture = scripture_2;
                        RunGame(scripture_2);
                        AskToSave(currentScripture);
                    }
                }
                break;

            case 3:
                referencesLines = LoadFromFile("./Files/references.csv");
                if (referencesLines == null || referencesLines.Length == 0)
                {
                    Console.WriteLine("No data loaded.");
                }
                else
                {
                    int id_Ref_Random = GetRandomId_Ref(referencesLines);
                    string[] textLines_3 = LoadFromFile("./Files/texts.csv");
                    if (textLines_3 == null || textLines_3.Length == 0)
                    {
                        Console.WriteLine("No data loaded.");
                    }
                    else
                    {
                        Reference referenceRandom = GetReferenceById(id_Ref_Random, referencesLines);
                        string text = GetText(id_Ref_Random, textLines_3);
                        Scripture scripture_3 = new Scripture(referenceRandom, text);
                        currentScripture = scripture_3;
                        RunGame(scripture_3);
                        AskToSave(currentScripture);
                    }
                }
                break;
        }
    }


    static void RunGame(Scripture scripture)
    {
        string option;
        int numberToHide = 2;

        Console.Clear();
        Console.WriteLine($"{scripture.GetDisplayText()}");
        Console.WriteLine();
        Console.WriteLine("Press enter to continue or type 'quit' to finish");
        option = Console.ReadLine();

        while (option != "quit" && !scripture.IsCompleteHidden())
        {
            scripture.HideRandomWords(numberToHide);
            Console.Clear();
            Console.WriteLine($"{scripture.GetDisplayText()}");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish");
            option = Console.ReadLine();
        }
    }
    

    static string[] LoadFromFile(string file)
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            return lines;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the file: {ex.Message}");
            return null;
        }
    }


    static void AskToSave(Scripture scripture)
    {
        Console.WriteLine("Do you want to save the current scripture?");
        Console.WriteLine("Type 'Y' for yes or 'N' for no:");
        string answer = Console.ReadLine()?.Trim().ToLower();

        if (answer == "y")
        {
            SaveReferenceToCsv("./Files/referencesSaved.csv", scripture.GetReference());
        }
        else
        {
            Console.WriteLine("Ok! Thank you! Goodbye!");
            Console.WriteLine("Press any key to exit the application.");
            Console.ReadKey();
        }
    }


    static void SaveReferenceToCsv(string filePath, Reference reference)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true = append
            {
                int id_ref = reference.GetId();
                string book = reference.GetBook()?.Trim();
                int chapter = reference.GetChapter();
                int verse = reference.GetVerse();
                int endVerse = reference.GetEndVerse();

                writer.WriteLine($"{id_ref}|{book}|{chapter}|{verse}|{endVerse}");
            }

            Console.WriteLine("Referência salva com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar a referência: {ex.Message}");
        }
    }


    static void ShowReferencesLines(string[] referencesLines)
    {
        Console.WriteLine("Available References");
        for (int i = 0; i < referencesLines.Length; i++)
        {
            string[] parts = referencesLines[i].Split('|');

            if (parts.Length < 5)
            {
                Console.WriteLine($"{i + 1} - Invalid format");
                continue;
            }

            bool parsedId_ref = int.TryParse(parts[0], out int id_Ref);
            string book = parts[1]?.Trim();
            bool parsedChapter = int.TryParse(parts[2], out int chapter);
            bool parsedVerse = int.TryParse(parts[3], out int verse);
            bool parsedEndVerse = int.TryParse(parts[4], out int endVerse);

            if (!parsedId_ref || !parsedChapter || !parsedVerse || !parsedEndVerse)
            {
                Console.WriteLine($"{i + 1} - Invalid numbers in reference");
                continue;
            }

            if (endVerse == verse)
            {
                Console.WriteLine($"{id_Ref} - {book} {chapter}:{verse}");
            }
            else
            {
                Console.WriteLine($"{id_Ref} - {book} {chapter}:{verse}-{endVerse}");
            }
        }
    }


    static Reference GetReferenceById(int id, string[] referenceLines)
    {
        foreach (string line in referenceLines)
        {
            string[] parts = line.Split('|');

            if (parts.Length < 5)
                continue;

            if (!int.TryParse(parts[0], out int id_Ref))
                continue;

            if (id_Ref == id)
            {
                string book = parts[1].Trim();
                int chapter = int.Parse(parts[2]);
                int verse = int.Parse(parts[3]);
                int endVerse = int.Parse(parts[4]);

                return new Reference(id_Ref, book, chapter, verse, endVerse);
            }
        }

        Console.WriteLine("Reference ID not found.");
        return null;
    }

    static int GetRandomId_Ref(string[] referenceLines)
    {
        Random random = new Random();
        int index = random.Next(0, referenceLines.Length);
        string[] parts = referenceLines[index].Split('|');
        int id_Ref = int.Parse(parts[0]);

        return id_Ref;
    }

        
    static string GetText(int id_Ref, string[] textLines)
    {
        foreach (string line in textLines)
        {
            string[] parts = line.Split('|');
            if (parts.Length < 2) continue;

            if (int.TryParse(parts[0], out int id) && id == id_Ref)
            {
                return parts[1];
            }
        }

        return "Text not found.";
    }

 
}