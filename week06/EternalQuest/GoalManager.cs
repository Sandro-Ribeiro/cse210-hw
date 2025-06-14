using System;
using System.Text;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goal");
            Console.WriteLine("  4. Load Goal");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    ListGoalDetails();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    MessageExit();
                    break;
            } 
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
        }
        else
        {
            Console.WriteLine("The list is empty!");
        }
    }

    public void ListGoalDetails()
    {
        string notCheck = "[ ]";
        string yesCheck = "[X]";

        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                if (_goals[i].IsComplete() == true)
                {
                    Console.WriteLine($"{i + 1}. {yesCheck} {_goals[i].GetDetailString()}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {notCheck} {_goals[i].GetDetailString()}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to back to menu");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine("The list is empty!");
            Console.WriteLine("Press any key to back to menu");
            Console.ReadKey();
        }
    }

    public void CreateGoal()
    {
        Console.Clear();    
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine();
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. ChecList Goal");
        Console.WriteLine();
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        string name;
        string description;
        int points;

        switch (type)
        {
            case 1:
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                Console.WriteLine();
                Console.WriteLine("Simple Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();
                break;
            case 2:
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                Console.WriteLine();
                Console.WriteLine("Eternal Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();

                break;
            case 3:
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                Console.Write("What is bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                CheckListGoal checkListGoal = new CheckListGoal(name, description, points, bonus, target);
                _goals.Add(checkListGoal);
                Console.WriteLine();
                Console.WriteLine("Checklist Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();
                break;
        }
    }

    public void RecordEvent()
    {
        Console.Clear();  
        Console.WriteLine("This goals are:");
        Console.WriteLine();
        ListGoalNames();
        Console.WriteLine();       
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine());
        _goals[index - 1].RecordEvent();
        int points = _goals[index - 1].GetPoints();
        _score += points;
        if (_goals[index - 1] is CheckListGoal checkListGoal && checkListGoal.IsComplete())
        {
            int bonus = checkListGoal.GetBonus();
            _score += bonus;
            Console.WriteLine($"Congratulations, You have earned {points} points and {bonus} of the bonus");
            Console.WriteLine($"You now have {_score} points");
        }
        else
        {
            Console.WriteLine($"Congratulations, You have earned {points} points");
            Console.WriteLine($"You now have {_score} points");
        }
        Console.WriteLine("Press any key to back to menu");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        Console.Clear();  
        Console.Write("What is the filename for the goal file?: ");
        string fileName = Console.ReadLine();

        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";           
        }

        Directory.CreateDirectory("./ListGoals");
        string pathFile = $"./ListGoals/{fileName}";

        using (StreamWriter outputFile = new StreamWriter(pathFile, false, Encoding.UTF8))
        {
            outputFile.WriteLine($"{_score}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }
        Console.WriteLine("Goal saved with sucess!");
        Console.WriteLine("Press any key to back to menu");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";           
        }

        string pathFile = $"./ListGoals/{fileName}";
        if (!File.Exists(pathFile))
        {
            Console.WriteLine("File not found!");
            Console.WriteLine("Press any key to back to menu");
            Console.ReadKey();
            return;
        }

        _goals.Clear();
        string[] lines = System.IO.File.ReadAllLines(pathFile);

        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] seps = [",", ":"];
            string[] parts = lines[i].Split(seps, StringSplitOptions.None);
            string typeGoal = parts[0].Trim();
            string shortname = parts[1].Trim();
            string description = parts[2].Trim();
            int points = int.Parse(parts[3].Trim());
            if (typeGoal == "Checklist Goal")
            {
                int bonus = int.Parse(parts[4].Trim());
                int target = int.Parse(parts[5].Trim());
                int amountCompleted = int.Parse(parts[6].Trim());
                CheckListGoal checkListGoal = new CheckListGoal(shortname, description, points, bonus, target, amountCompleted);
                _goals.Add(checkListGoal);
            }
            else if (typeGoal == "Simple Goal")
            {
                bool isComplete = bool.Parse(parts[4]);
                SimpleGoal simpleGoal = new SimpleGoal(shortname, description, points, isComplete);
                _goals.Add(simpleGoal);
            }
            else
            {
                EternalGoal eternalGoal = new EternalGoal(shortname, description, points);
                _goals.Add(eternalGoal);
            }
        }
    }

    public void MessageExit()
    {
        Console.Clear();
        Console.WriteLine("Thank you for using Eternal Quest!");
        Console.WriteLine("Keep striving for your goals. See you next time!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
        Console.Clear();     
    }
}