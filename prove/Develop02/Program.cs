using System;
using System.Diagnostics.Contracts;
using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        List<Entry> Journal = new List<Entry>();

        int MenuSelect = 0;

        
        
        Console.WriteLine("Welcome to the journal entry program");
        Console.WriteLine("This program prompts you for questions and saves your answers with a time stamp.");

        while (MenuSelect != 5)
        {
            string fileName = "";
            Console.WriteLine("1. Write in journal");
            Console.WriteLine("2. Display loaded journal");
            Console.WriteLine("3. Load saved journal");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Quit journaling");

            // Read user input and convert it to an integer
            MenuSelect = int.Parse(Console.ReadLine());
            Console.WriteLine($"Hey it worked {MenuSelect}");
            // Perform actions based on user input
            switch (MenuSelect)
            {
                case 1:
                    // Write in the journal
                    Console.WriteLine("Writing in journal...");
                    PromptGenerator question = new PromptGenerator();
                    
                    string prompt = question.GeneratePrompt();
                    Console.WriteLine(prompt);
                    Console.WriteLine("Enter your journal entry:");
                    
                    string entrywords = Console.ReadLine();
                    DateTime date = DateTime.Now;
                    Entry entry = new Entry(date, prompt, entrywords);
                    Journal.Add(entry);
                    break;
                case 2:
                    // Display loaded journal
                    Console.WriteLine("Displaying loaded journal...");
                    //Console.WriteLine(journal);
                    foreach (Entry journalentry in Journal)
                    {
                    Console.WriteLine($"{journalentry.date}: {journalentry.prompt} {journalentry.entry}");
                    }
                    break;
                case 3:
                    // Load saved journal from file
                    Console.WriteLine("Loading saved journal from file...");
                    
                    Console.WriteLine("Enter file name");
                    fileName = Console.ReadLine();
                    
                    if (File.Exists(fileName))
                    {
                    //    journal = File.ReadAllText("journal.txt");string filename = "myFile.txt";
                    string[] lines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);

                    }
                    }
                    else
                    {
                        Console.WriteLine("No saved journal found.");
                    }
                    break;
                case 4:
                    // Save journal to a text file
                    Console.WriteLine("Saving journal to file...");
                    
                    Console.WriteLine("Enter file name");
                    fileName = Console.ReadLine();
                    


                    

                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        // You can add text to the file with the WriteLine method
                    
                    foreach (Entry journalentry in Journal)
                        {
                        outputFile.WriteLine($"{journalentry.date}: {journalentry.prompt} {journalentry.entry}");
                        }
                        // You can use the $ and include variables just like with Console.WriteLine
                    

                    Console.WriteLine("Journal saved to journal.txt.");
                    break;
                    }
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
