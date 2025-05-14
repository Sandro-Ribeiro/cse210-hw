using System;
using System.ComponentModel.DataAnnotations;

public class Resume
{
    public string _personName;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        for (int i = 0; i < _jobs.Count; i++)
        {
            Console.WriteLine($"{_jobs[i]._jobtitle}");
        }
    }

}