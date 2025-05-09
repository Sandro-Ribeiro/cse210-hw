using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements

        List<int> numbers = new List<int>();
        int number;
        int sum_numbers;
        double average_numbers;
        int max_number;
        int minPositiveNumber = int.MaxValue;

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

        // Stretch Challenge

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 0 && numbers[i] < minPositiveNumber)
            {
                minPositiveNumber = numbers[i];
            }
        }

        if (minPositiveNumber != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {minPositiveNumber}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered");
        }

        numbers.Sort();

        Console.WriteLine("The sorted list is: ");

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}