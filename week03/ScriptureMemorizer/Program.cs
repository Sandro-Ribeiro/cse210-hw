using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        string book;
        int chapter;
        int verse;
        int endVerse;
        string text;

        book = "Alma";
        chapter = 34;
        verse = 30;
        endVerse = 32;
        text = "And now, my brethren, I would that, after ye have received so many witnesses," +
        " seeing that the holy scriptures testify of these things, ye come forth and bring fruit unto repentance." +
        " Yea, I would that ye would come forth and harden not your hearts any longer; for behold, now is the time" +
        " and the day of your salvation; and therefore, if ye will repent and harden not your hearts, immediately" +
        " shall the great plan of redemption be brought about unto you.For behold, this life is the time for men to" +
        " prepare to meet God; yea, behold the day of this life is the day for men to perform their labors.";

        Reference reference = new Reference(book, chapter, verse, endVerse);
        Scripture scripture = new Scripture(reference, text);

        Console.WriteLine("What you want to do: ");
        Console.WriteLine("1. To try Current Scripture");
        Console.WriteLine("2. To try Random Scripture");
        Console.WriteLine("3. To Choose new scripture");
        Console.WriteLine("3. To save scripture");

        Console.WriteLine("Enter your choose");

        int _choose = int.Parse(Console.ReadLine());

        switch (_choose)
        {
            case 1:
                
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }

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
    

    public static void SaveReferenceToCsv(string filePath, Reference reference)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true = append
            {
                string book = reference.GetBook().Trim();
                int chapter = reference.GetChapter();
                int verse = reference.GetVerse();
                int endVerse = reference.GetEndVerse();

                writer.WriteLine($"{book},{chapter},{verse},{endVerse}");
            }

            Console.WriteLine("Referência salva com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar a referência: {ex.Message}");
        }
    }



    static Reference GetReferenceUser()
    {
        Console.WriteLine("Enter with book´s name: ");
        string book = Console.ReadLine();
        Console.WriteLine("Enter with Chapter number: ");
        int chapter = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter with first verse number: ");
        int verse = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter with last verse number: ");
        int endVerse = int.Parse(Console.ReadLine());

        Reference reference = new Reference(book, chapter, verse, endVerse);

        return reference;

    }


    static Reference SelectRandomReferenceLine(string[] referenceLines)
    {
        Random random = new Random();
        int index = random.Next(1, referenceLines.Length);
        string[] parts = referenceLines[index].Split(',');
        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        int verse = int.Parse(parts[2]);
        int endVerse = int.Parse(parts[3]);
        Reference reference = new Reference(book, chapter, verse, endVerse);

        return reference;

    }
    
    static string GetText(Reference reference, string[] textLines)
    {
        string book = reference.GetBook().Trim();
        int chapter = reference.GetChapter();
        int verse = reference.GetVerse();
        int endVerse = reference.GetEndVerse();

        string fullText = "";
        bool collecting = false;

        foreach (string line in textLines)
        {
            string[] parts = line.Split(',');

            if (parts.Length < 5) continue;

            string lineBook = parts[0].Trim();
            int lineChapter = int.Parse(parts[1]);
            int lineVerse = int.Parse(parts[2]);
            int lineEndVerse = int.Parse(parts[3]);
            string text = parts[4];

            if (lineBook == book && lineChapter == chapter)
            {
                if (!collecting && lineVerse == verse)
                {
                    collecting = true;
                }

                if (collecting)
                {
                    fullText += $" {text}";

                    if (lineVerse == lineEndVerse)
                    {
                        break;
                    }
                }
            }
        }
        return fullText.Trim();
    }  
}