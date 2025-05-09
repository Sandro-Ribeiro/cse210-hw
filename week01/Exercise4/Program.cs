using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;
        int sum_numbers;
        double average_numbers;
        int max_number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        do
        {
            Console.WriteLine("Enter number: ");
            string stringNumber = Console.ReadLine();

            number = int.Parse(stringNumber);

            if (number != 0)
            {
                numbers.Add(number);
            }         
        }while(number != 0);

        sum_numbers = numbers.Sum();
        average_numbers = numbers.Average();
        max_number = numbers.Max();

        Console.WriteLine($"The sum is: {sum_numbers}");
        Console.WriteLine($"The average is: {average_numbers}");
        Console.WriteLine($"The largest number is: {max_number}");

    }
}