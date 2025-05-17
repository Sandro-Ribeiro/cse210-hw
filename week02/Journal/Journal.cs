using System;
using System.IO;
using System.IO.Enumeration;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    int _choice;

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file, true))
            {
                for (int i = 0; i < _entries.Count; i++)
                {
                    outputFile.WriteLine("-----------------------------------------------------------------");
                    outputFile.WriteLine(_entries[i]._date);
                    outputFile.WriteLine(_entries[i]._promptText);
                    outputFile.WriteLine(_entries[i]._entryText);
                    outputFile.WriteLine();
                }
            }

            Console.WriteLine("File saved sucessfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the file: {ex.Message}");
        }

    }

    public void RunJournal()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                                                                              *");
            Console.WriteLine("*                                JOURNAL DAILY                                 *");
            Console.WriteLine("*                                                                              *");
            Console.WriteLine("*                                    Welcome!                                  *");
            Console.WriteLine("*                                                                              *");
            Console.WriteLine("*                             Autor: Sandro Ribeiro                            *");
            Console.WriteLine("*                                                                              *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Please, select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:
                    Console.Clear();
                    PromptGenerate _prompt = new PromptGenerate();
                    Entry _entry = new Entry();
                    DateTime theCurrentTime = DateTime.Now;
                    _entry._promptText = _prompt.GetRandomPrompt();
                    Console.WriteLine($"{_entry._promptText}");
                    Console.WriteLine();
                    _entry._entryText = Console.ReadLine();
                    _entry._date = theCurrentTime.ToShortDateString();
                    AddEntry(_entry);
                    Console.Clear();
                    Console.WriteLine("Registration completed successfully");
                    Program.Pause("Press Enter to return to the menu.");

                    break;

                case 2:
                    Console.Clear();
                    DisplayAll();
                    Console.WriteLine();
                    Program.Pause("Press Enter to return to the menu.");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("What is the filename? ");
                    string fileToLoad = Console.ReadLine();
                    Console.Clear();
                    LoadFromFile(fileToLoad);
                    Program.Pause("Press Enter to return to the menu.");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("What is the filename? ");
                    string fileToSave = Console.ReadLine();
                    Console.Clear();
                    SaveToFile(fileToSave);
                    Program.Pause("Press Enter to return to the menu.");
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("********************************************************************************");
                    Console.WriteLine("*        Congratulations on persevering in keeping your journal!               *");
                    Console.WriteLine("*         I'm already looking forward to tomorrow's experiences                *");
                    Console.WriteLine("*                                                                              *");
                    Console.WriteLine("*              Remember, your Heavenly Father loves effort                     *");
                    Console.WriteLine("*     Continue to persevere and you and your posterity will be blessed         *");
                    Console.WriteLine("*                                                                              *");
                    Console.WriteLine("*                              See you tomorrow                                *");
                    Console.WriteLine("*                                                                              *");
                    Console.WriteLine("********************************************************************************");
                    Console.WriteLine();
                    Program.Pause("Press Enter to return to the menu.");
                    Console.Clear();
                    break;
            }

        } while (_choice != 5);
                
    }
}