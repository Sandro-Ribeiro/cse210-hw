using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,101);

        int guess;
        int counting = 0;

        do
        {
            Console.WriteLine("What is your guess? ");
            string  stringGuess = Console.ReadLine();

            counting += 1;

            guess = int.Parse(stringGuess);

            if (guess > number )
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine($"Congratulations!! You guessed on the {counting}º try!!");
            }
        }while (number != guess);
    }
}