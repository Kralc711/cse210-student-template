using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._timeEmployed = "2019-2022";
        
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._timeEmployed = "2022-2023";
        Resume resume = new Resume();
        resume.Name = "Clark Rushton";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.display();
    }
}