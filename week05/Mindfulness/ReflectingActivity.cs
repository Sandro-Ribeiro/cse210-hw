using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity:Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private static Random random = new Random();

    public ReflectingActivity() : base()
    {
        SetName("Refleting Activity");
        SetDescripton(
            "This activity will help you reflect on times in your life when " +
            "you have shown strength and resilience. This will help you recognize " +
            "the power you have and how you can use it in other aspects of your life."
            );

        _prompts.AddRange(new[]
            {
                "Think of a time when you stood up for someone else",
                "Think of a time when you did something really difficult",
                "Think of a time when you helped someone in need",
                "Think of a time when you did something truly selfless"
            });

        _questions.AddRange(new[]
            {
                "Why was this experience meaningful to you? ",
                "Have you ever done anything like this before? ",
                "How did you get started? ",
                "How did you feel when it was complete? ",
                "What made this time different than other times when you were not as successful? ",
                "What is your favorite thing about this experience? ",
                "What could you learn from this experience that applies tother situations? ",
                "What did you learn about yourself through this experience? ",
                "How can you keep this experience in mind in the future? "
            }); 
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(10);

        Console.WriteLine("Consider the following prompt\n");
        Console.WriteLine($"---{GetRandomPrompt()}\n");
        Console.WriteLine(
            "When you have something in mind, " +
            "press enter to continue\n"
            );
        Console.ReadKey();
        
        Console.Write(
            "Now, ponder on each of the following questions " +
            "as they related to this experience\n"
            );

        CountDown("You may begin in", 5);

        Console.WriteLine("\nPress enter to exit");

        do
        {
            Console.Clear();
            Console.WriteLine(GetRandomQuestion());
            Console.Write("\nPress enter to exit");
            CountDown("The question will change in", 5);


        } while (!Console.KeyAvailable);
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"{prompt}");
    }

    public void DisplayQuestions()
    {
        string question = GetRandomQuestion();
        Console.WriteLine($"{question}");
    }
}