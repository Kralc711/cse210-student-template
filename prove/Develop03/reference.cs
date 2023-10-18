public class Reference{
    private string _book;

    private int _chapter;

    private int _verse;

    public string SetBook()
    {
        Console.WriteLine("Enter book of Scripture");
        string book = Console.ReadLine(); 
        return book;
    }

    public int SetChapter()
    {
        Console.WriteLine("Enter chapter");
        
        int chapter = int.Parse(Console.ReadLine());
        
        return chapter;
    }

    public int SetVerse()
    {
        Console.WriteLine("Enter verse");
        int verse = int.Parse(Console.ReadLine()):
        return verse;
    } 
    public string Getbook()
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

}