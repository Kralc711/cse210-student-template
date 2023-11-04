using System;

class Program
{
    static void Main()
    {
        int menu = 0;
        while(menu != 4)
        {
            Console.WriteLine("Reflection Activity 1 ");
            Console.WriteLine("Breathing Activity 2 ");
            Console.WriteLine("Listing Activity 3 ");
            Console.WriteLine("Close 4 ");
            menu = int.Parse(Console.ReadLine());
            switch(menu)
            {
                case 1:
                
                LoadingBar(5);

                break;
                case 2:
                
                LoadingBar(30);
                
                break;
                case 3:
                
                LoadingBar(7);
                
                break;

            }
        
        }
    }


    static void LoadingBar(int BarLength)
    {
        string bar = "░";
        while(bar.Length < BarLength*10)
        {
            bar = bar + "░";
        }

        Random random = new Random();
        Console.WriteLine(bar); // Print the current string
        for (int i = 0; i < bar.Length; i++)
        {
            
            bar = bar.Remove(bar.LastIndexOf('░'), 1).Insert(0, "▓"); // Replace one '+' with '-'

            // Generate a random wait time with mean of 1.5 seconds and standard deviation of 0.5 seconds
            double mean = 0.1; // mean in seconds
            double stdDev = 0.1; // standard deviation in seconds

            // Generate a random number from a normal distribution with mean and standard deviation
            double delay = Math.Max(0, random.NextGaussian(mean, stdDev));

            int milliseconds = (int)(delay * 1000); // Convert seconds to milliseconds

            System.Threading.Thread.Sleep(milliseconds); // Add a random delay to slow down the output

            Console.Clear(); // Clear the console
            Console.WriteLine(bar); // Print the current string
        }
        Console.Clear(); // Clear the console
        Console.WriteLine("Finished");
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
