using System;
using System.Runtime.InteropServices;

class Program
{
    public static void Pause(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        myJournal.RunJournal();

    }
}