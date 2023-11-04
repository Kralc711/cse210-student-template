using System;

class Program
{
    static void Main()
    {
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        Console.Write("Enter the duration of the activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose an activity: (1) Breathing, (2) Reflection, (3) Listing");
        string activityChoice = Console.ReadLine();

        Activity activity = null;
        switch (activityChoice)
        {
            case "1":
                LoadingBar(2);
                activity = new BreathingActivity(duration);
                break;
            case "2":
                LoadingBar(2);
                activity = new ReflectionActivity(duration);
                break;
            case "3":
                LoadingBar(2);
                activity = new ListingActivity(duration);
                break;
            default:
                LoadingBar(2);
                Console.WriteLine("Invalid choice.");
                return;
        }

        activity.StartActivity();
    }
    }


    static void LoadingBar(int BarLength)
    {
        string bar = "░";
        while(bar.Length < BarLength*50)
        {
            bar = bar + "░";
        }

        Random random = new Random();
        Console.WriteLine("Loading: ["+bar+"]"); // Print the current string
        for (int i = 0; i < bar.Length; i++)
        {
            
            bar = bar.Remove(bar.LastIndexOf('░'), 1).Insert(0, "▓"); // Replace one '+' with '-'

            // Generate a random wait time with mean of 1.5 seconds and standard deviation of 0.5 seconds
            double mean = 0.01; // mean in seconds
            double stdDev = 0.05; // standard deviation in seconds

            // Generate a random number from a normal distribution with mean and standard deviation
            double delay = Math.Max(0, random.NextGaussian(mean, stdDev));

            int milliseconds = (int)(delay * 1000); // Convert seconds to milliseconds

            System.Threading.Thread.Sleep(milliseconds); // Add a random delay to slow down the output

            Console.Clear(); // Clear the console
            Console.WriteLine("Loading: ["+bar+"]"); // Print the current string
        }
        Console.Clear(); // Clear the console
        
    }
}

public static class RandomExtensions
{
    public static double NextGaussian(this Random random, double mean, double stdDev)
    {
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double normalRandom = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * normalRandom;
    }
}
