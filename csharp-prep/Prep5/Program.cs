using System;

class Program
{
    static void Main()
    {
        // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function and store the user's name
        string userName = PromptUserName();

        // Call PromptUserNumber function and store the user's favorite number
        int userNumber = PromptUserNumber();

        // Call SquareNumber function to calculate the square of the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function to display the user's name and squared number
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name and return it as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a given number and return the result as an integer
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
