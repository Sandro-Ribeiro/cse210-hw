using System;

class Program
{
    static void Main(string[] args)
    {
       // Instantiating of an object of the Job class
       Job job1 = new Job();
       Job job2 = new Job();

       job1._company = "Microsoft";
       job1._jobtitle = "Software Engineer";
       job1._startYear = 2019;
       job1._endYear = 2022;

       job2._company = "Apple";
       job2._jobtitle = "Manager";
       job2._startYear = 2022;
       job2._endYear = 2023;

       Console.WriteLine($"{job1._company}");
       Console.WriteLine($"{job2._company}");

       job1.Display();
       job2.Display();

       Resume myResume = new Resume();

       myResume._personName = "Allison Rose";
       myResume._jobs.Add(job1);
       myResume._jobs.Add(job2);

       Console.WriteLine($"{myResume._jobs[0]._jobtitle}");

       myResume.Display();
       
    }
}