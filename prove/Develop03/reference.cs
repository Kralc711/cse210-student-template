using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    public void SetBook()
    {
        Console.WriteLine("Enter book of Scripture");
        _book = Console.ReadLine();
    }

    public void SetChapter()
    {
        Console.WriteLine("Enter chapter");
        _chapter = int.Parse(Console.ReadLine());
    }

    public void SetVerse()
    {
        Console.WriteLine("Enter verse");
        _verse = int.Parse(Console.ReadLine());
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    // Example of how to use the setter and getter methods
    public void DisplayReference()
    {
        Console.WriteLine($"Reference: {_book} {_chapter}:{_verse}");
    }
}