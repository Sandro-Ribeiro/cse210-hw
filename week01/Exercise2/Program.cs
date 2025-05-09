using System;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string grade = Console.ReadLine();

        float floatGrade = float.Parse(grade);
        float gradeRest = floatGrade % 10;
        string letter;

        if (floatGrade >= 90)
        {
            if (gradeRest < 3)
            {
                letter = "A-";
            }
            else
            {
                letter = "A";
            }
        }
        else if (floatGrade >= 80)
        {
            if (gradeRest > 7)
            {
                letter = "B+";
            }
            else if (gradeRest < 3)
            {
                letter = "B-";
            }
            else
            {
                letter = "B";
            }
        }
        else if (floatGrade >= 70)
        {
            if (gradeRest > 7)
            {
                letter = "C+";
            }
            else if (gradeRest < 3)
            {
                letter = "C-";
            }
            else
            {
                letter = "C";
            }
        }
        else if (floatGrade >= 60)
        {
            if (gradeRest > 7)
            {
                letter = "D+";
            }
            else if (gradeRest < 3)
            {
                letter = "D-";
            }
            else
            {
                letter = "D";
            }
        }
        else
        {
            letter = "F";
        }

        if (floatGrade >= 70)
        {
            Console.WriteLine($"Congratulations on your grade! Your grade was {letter}.");
            Console.WriteLine("You passed the course!");
        }
        else
        {
            Console.WriteLine($"Unfortunately, your grade was {letter}.");
            Console.WriteLine("This grade is not good enough for you to pass the course.");
            Console.WriteLine("But don't give up, I'm sure you'll do better next time.");
        }
    }
}