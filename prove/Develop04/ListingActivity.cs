using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private static string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
    }

    public override void StartActivity()
    {
        ShowStartingMessage();

        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"Think about: {prompt}");

        LoadingBar(5); // Give the user 5 seconds to think about the prompt

        Console.WriteLine("Begin listing items...");

        List<string> itemsList = new List<string>();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("Enter an item (or 'done' to finish): ");
            string item = Console.ReadLine();

            if (item.ToLower() == "done")
            {
                break;
            }

            itemsList.Add(item);
        }

        Console.WriteLine($"You listed {itemsList.Count} items.");
        ShowEndingMessage();
    }
}