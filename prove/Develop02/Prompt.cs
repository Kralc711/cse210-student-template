using System;

public class PromptGenerator
{
    private string[] prompts = {
        "Who was the most interesting person you met today?",
        "Describe a moment that made you laugh today.",
        "What is something new you learned recently?",
        "Write about a place you'd like to visit and why.",
        "If you could have any superpower, what would it be and why?",
        "Describe a favorite childhood memory.",
        "What is a hobby or activity that brings you joy?",
        "Write about a goal you want to achieve in the next year.",
        "Describe a book, movie, or TV show that had a significant impact on you.",
        "If you could have dinner with any historical figure, who would it be and why?"
    };

    public string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        
        
        return prompts[index];
    }
}  