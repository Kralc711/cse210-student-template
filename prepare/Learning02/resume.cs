using System.Reflection;

public class Resume{
public string Name { get; set; }

public List<Job> _jobs = new List<Job>();

public void display()

{
Console.WriteLine($"Name: {Name}");
Console.WriteLine("Jobs: ");
foreach (Job job  in _jobs)
{
    job._printDetails();
}

}

}