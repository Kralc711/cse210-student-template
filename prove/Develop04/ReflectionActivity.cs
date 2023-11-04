using System;
using System.Threading;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private static string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
    }

    public override void StartActivity()
    {
        ShowStartingMessage();

        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);

        LoadingBar(5); // Give the user 5 seconds to think about the prompt

        Console.WriteLine("Reflect on the following questions:");

        Random random = new Random();
        foreach (var question in GetRandomQuestions())
        {
            Console.WriteLine(question);
            LoadingSpinner(4); // Pause for 4 seconds with a spinner
        }

        ShowEndingMessage();
    }

    private List<string> GetRandomQuestions()
    {
        List<string> selectedQuestions = new List<string>();
        Random random = new Random();

        while (selectedQuestions.Count < Duration)
        {
            string randomQuestion = reflectionQuestions[random.Next(reflectionQuestions.Length)];
            if (!selectedQuestions.Contains(randomQuestion))
            {
                selectedQuestions.Add(randomQuestion);
            }
        }

        return selectedQuestions;
    }

    private void LoadingSpinner(int durationInSeconds)
    {
        string[] spinner = { "|", "/", "─", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            foreach (var spin in spinner)
            {
                Console.Write($"\r {spin} "); // Use carriage return to overwrite the line
                Thread.Sleep(250);
            }
        }

        Console.WriteLine(); // Move to the next line after the loading spinner
    }
}
