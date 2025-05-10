using System;

class Program
{
    
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter with your name: ");
        string userName = Console.ReadLine();
        
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter with favourite number: ");
        string favouriteNumber = Console.ReadLine();

        int number = int.Parse(favouriteNumber);

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
    
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, square);
    }
}