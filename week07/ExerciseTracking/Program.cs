using System;
using System.Globalization;

class Program
{
    static Random random = new Random();
    static Dictionary<string, Type> activityTypes = new Dictionary<string, Type>
    {
        { "Running", typeof(Running) },
        { "Swimming", typeof(Swimming) },
        { "Cycling", typeof(Cycling) }
    };

    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        DateTime dateTimeNow = DateTime.Now;
        int hour = dateTimeNow.Hour;

        if (hour >= 6 && hour < 12)
        {
            Console.WriteLine("Hello! Good morning!! \n");
        }
        else if (hour >= 12 && hour < 18)
        {
            Console.WriteLine("Hello! Good afternoon!! \n");
        }
        else
        {
            Console.WriteLine("Hello! Good night!! \n");
        }

        Console.WriteLine("How many activities do you want to do today?");

        int number;

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Please, enter a valid number");
        }

        for (int i = 0; i < number; i++)
        {

            Type activityType = DefineActivityType();
            int duration = DefineDuration();
            DateTime date = DefineDate();

            if (activityType == typeof(Running))
            {
                double distance = DefineDistance();
                Running activity = new Running(date, duration, distance);
                activities.Add(activity);

            }
            else if (activityType == typeof(Swimming))
            {
                int numberOfLaps = DefineNumberOfLaps();
                Swimming activity = new Swimming(date, duration, numberOfLaps);
                activities.Add(activity);
            }
            else
            {
                double speed = DefineSpeed();
                Cycling activity = new Cycling(date, duration, speed);
                activities.Add(activity);
            }
        }

        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }
    }

    public static Type DefineActivityType()
    {
        string[] activities = { "Running", "Swimming", "Cycling" };
        int indexActivity = random.Next(activities.Length);
        string selectedActivity = activities[indexActivity];

        return activityTypes[selectedActivity];
    }

    public static int DefineDuration()
    {
        int[] durations = { 15, 20, 30, 45, 60, 90 };
        int indexDuration = random.Next(durations.Length);
        return durations[indexDuration];
    }

    public static DateTime DefineDate()
    {
        int maxDays;
        int month = random.Next(1, 13);
        int year = 2025;

        if (month == 2)
        {
            if (DateTime.IsLeapYear(year))
            {
                maxDays = 29;
            }
            else
            {
                maxDays = 28;
            }
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            maxDays = 30;
        }
        else
        {
            maxDays = 31;
        }

        int day = random.Next(1, maxDays + 1);

        DateTime activityDate = new DateTime(year, month, day);

        return activityDate;
    }

    public static double DefineDistance()
    {
        double start = 15;
        double stop = 45;
        double step = 5;

        int count = (int)Math.Ceiling((stop - start) / step);

        double[] distances = Enumerable.Range(0, count)
                         .Select(i => start + i * step)
                         .ToArray();

        int indexDistance = random.Next(distances.Length);
        double distance = distances[indexDistance];

        return distance;
    }

    public static int DefineNumberOfLaps()
    {
        int[] numberOfLaps = { 10, 20, 30, 40, 60, 90 };
        int indexNumberOfLaps = random.Next(numberOfLaps.Length);
        return numberOfLaps[indexNumberOfLaps];
    }

    public static double DefineSpeed()
    {
        double[] speeds = { 6, 8, 10, 12, 14, 16 };
        int indexSpeed = random.Next(speeds.Length);
        return speeds[indexSpeed];
    }
}