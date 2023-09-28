using System.Reflection;

public class Job{
public string _jobTitle { get; set; }

public string _company { get; set; }
public string _timeEmployed { get; set; }

public void _printDetails()
{
Console.WriteLine($"{_jobTitle}, {_company}, {_timeEmployed}");

}


}