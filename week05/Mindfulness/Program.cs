using System;

class Program
{
    static void Main(string[] args)
    {
        int _choice;
        do
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine();
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start refleting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu ");

            _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for yopur session? ");
                    int duration = int.Parse(Console.ReadLine());
                    breathingActivity.SetDuration(duration);
                    breathingActivity.Run();
                    breathingActivity.DisplayEndingMessage();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for yopur session? ");
                    duration = int.Parse(Console.ReadLine());
                    reflectingActivity.SetDuration(duration);
                    reflectingActivity.Run();
                    reflectingActivity.DisplayEndingMessage();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for yopur session? ");
                    duration = int.Parse(Console.ReadLine());
                    listingActivity.SetDuration(duration);
                    listingActivity.Run();
                    listingActivity.DisplayEndingMessage();
                    break;
                case 4:
                    Console.WriteLine("");
                    break;
            }
        } while (_choice != 4);
    }
}