using System;
using System.Runtime.CompilerServices;
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
        Console.WriteLine("Menu Options");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goal");
        Console.WriteLine("  4. Load Goal");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. ");
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Select ");

                break;
            case 2:
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

    public int DisplayPlayerInfo()
    {
        return _score;
    }

    public string ListGoalNammes()
    {
        foreach (Goal goal in _goals)
        {
            
        }
        return $"";

    }

    public string ListGoalDetails()
    {
        return $"";

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
                break;
            case 2:
                Console.WriteLine("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.WriteLine("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.WriteLine("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.WriteLine("What is a short descrition of it? ");
                description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                CheckListGoal checkListGoal = new CheckListGoal(name, description, points);
                break;
        }
    }

    public void RecordEvent()
    {

    }

    public void SaveGoals()
    {

    }

    public void LoadGoals()
    {
        
    }
}