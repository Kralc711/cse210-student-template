using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    {
    }

    public override void StartActivity()
    {
        ShowStartingMessage();
        Console.WriteLine("Get ready to breathe...");

        

        for (int i = 0; i < Duration/5; i++)
        {
            Console.WriteLine("Breathe in...");
            LoadingBar(2); // Call the LoadingBar method for 2 seconds (duration of breathing in)
            Console.WriteLine("Breathe out...");
            LoadingBar(3); // Call the LoadingBar method for 2 seconds (duration of breathing out)
        }

        ShowEndingMessage();
    }
}
