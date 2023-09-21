using System;

class Program
{
    static void Main()
    {
    Random random = new Random();
    int magicNumber = random.Next(1, 20);
    
    
        Console.WriteLine("Guess the magic number");
        
        int guess;
        bool guessedCorrectly = false;
    do
    {
        Console.Write("\nWhat is your guess? ");
        guess = int.Parse(Console.ReadLine());
      
        if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        } 
        else if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("You guessed it!");
            guessedCorrectly = true;
        }
     } while (!guessedCorrectly);
    }
}