using System.ComponentModel;
using System.Security.AccessControl;

public class Activity
{
    private string _name;
    private string _descripton;
    private int _duration;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescripton(string descripton)
    {
        _descripton = descripton;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public string  GetName()
    {
        return _name;
    }

    public string GetDescripton()
    {
        return _descripton;
    }

    public int GetDuration()
    {
        return _duration;
    }


    public void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.Write($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_descripton}");
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!\n");
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the {_name}");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();

    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                break;
            }
            Console.Write(spinner[index % spinner.Length]);
            Thread.Sleep(100);
            Console.Write("\b \b");
            index++;
        }
    }

    public void CountDown(string sentence, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            if (Console.KeyAvailable)
            {
                break;
            }
            string fullText = $"{sentence} {i}";
            Console.Write($"\r{fullText}");
            Thread.Sleep(1000);
        }
        Console.Write($"\r{sentence}          ");
        Console.WriteLine();
    }

}