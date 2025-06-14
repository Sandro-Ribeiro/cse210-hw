using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;

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
        Console.Clear();
        DisplayPlayerInfo();
        Console.WriteLine();
        Console.WriteLine("Menu Options");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goal");
        Console.WriteLine("  4. Load Goal");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. ");
        Console.WriteLine();
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CreateGoal();
                break;
            case 2:
                ListGoalDetails();
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }

    public void DisplayPlayerInfo()
    {
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete() == true)
            {
                _score += goal.GetPoints();
            }
        }
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetShortName());
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
            for(int i = 0; i < _goals.Count; i++)
            {
                if (_goals[i].IsComplete() == true)
                {
                    Console.WriteLine($"{i+1}. {yesCheck} {_goals[i].GetDetailString()}");
                }
                else
                {
                    Console.WriteLine($"{i+1}. {notCheck} {_goals[i].GetDetailString()}");
                }
            }
        }
        else
        {
            Console.WriteLine("The list is empty!");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. ChecList Goal");
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        string name;
        string description;
        int points;

        switch (type)
        {
            case 1:
                Console.WriteLine("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.WriteLine("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                Console.WriteLine("Simple Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.WriteLine("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                Console.WriteLine("Eternal Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();

                break;
            case 3:
                Console.WriteLine("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.WriteLine("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the amount of points associated with this goal? ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the amount of points associated with this goal? ");
                int bonus = int.Parse(Console.ReadLine());
                CheckListGoal checkListGoal = new CheckListGoal(name, description, points, target, bonus);
                _goals.Add(checkListGoal);
                Console.WriteLine("Checklist Goal added with sucess!");
                Console.WriteLine("Press any key to back to menu");
                Console.ReadKey();
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("This goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"1. {goal.GetShortName()}");
        }
        Console.Write("Which goal did you accomplish: ");
        int index = int.Parse(Console.ReadLine());
        _goals[index - 1].RecordEvent();
        int points = _goals[index - 1].GetPoints();
        _score += points;
        Console.WriteLine($"Congratulations, You have earned {points} points");
        Console.WriteLine($"You now have {_score} points");
        Console.WriteLine("Press any key to back to menu");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        string pathFile = "./lists/goals.txt";

        using (StreamWriter outputFile = new StreamWriter(pathFile))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");  
            }
        }

    }

    public void LoadGoals()
    {
        string pathFile = "./lists/goals.txt";
        string[] lines = System.IO.File.ReadAllLines(pathFile);

        foreach (string line in lines)
        {
            Console.WriteLine($"{line}");
        }
    }
}