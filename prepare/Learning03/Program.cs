using System;

class Program
{
    static void Main(string[] args)
    {
        int MenuSelect = 0;
        Console.WriteLine("Welcome to the journal entry program");
        Console.WriteLine("This program prompts you for questions and saves your answers with a time stamp.");

        while (MenuSelect != 5)
        {
            Console.WriteLine("1. Write in journal");
            Console.WriteLine("2. Display loaded journal");
            Console.WriteLine("3. Load saved journal");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Quit journaling");

            // Read user input and convert it to an integer
            MenuSelect = int.Parse(Console.ReadLine());

            // Perform actions based on user input
            switch (MenuSelect)
            {
                case 1:
                    // Call entry class to write in the journal
                    Console.WriteLine("Writing in journal...");
                    break;
                    PromptGenerator prompt = new PromptGenerator();
                    Console.WriteLine(prompt);
                case 2:
                    // Call print method in entry class to display loaded journal
                    Console.WriteLine("Displaying loaded journal...");
                    break;
                case 3:
                    // Pull data from a text file to load saved journal
                    Console.WriteLine("Loading saved journal from file...");
                    break;
                case 4:
                    // Save journal to a text file
                    Console.WriteLine("Saving journal to file...");
                    break;
                case 5:
                    // Exit the program
                    Console.WriteLine("Goodbye.");
                    break;
                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
