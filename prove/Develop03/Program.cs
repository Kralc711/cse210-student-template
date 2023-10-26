

class Program
{
    static void Main(string[] args)
    {
        Words words = new Words();

        Reference reference1 = new();
            reference1.SetBook();
            reference1.SetChapter();
            reference1.SetVerse();

            reference1.DisplayReference();

        Scripture scripture1 = new Scripture();
        

        string ScriptureCall1 = scripture1.ScriptureCaller(reference1.GetBook() ,reference1.GetChapter() ,reference1.GetVerse());

        words.AddWord(ScriptureCall1);

        Console.WriteLine("Would you like a second verse? (type yes)");
        string secondBreakfast = Console.ReadLine();

        if (secondBreakfast=="yes")
        {
            Reference reference2 = new Reference();
                reference2.SetBook();
                reference2.SetChapter();
                reference2.SetVerse();

                reference2.DisplayReference();

            Scripture scripture2 = new Scripture();
            

            string ScriptureCall2 = scripture2.ScriptureCaller(reference2.GetBook() ,reference2.GetChapter() ,reference2.GetVerse());
            

            words.AddWord(ScriptureCall2);

            string exit = "";
            while(exit != "exit")
                {
                words.PrintAsParagraph();
                exit = Console.ReadLine();
                Console.Clear();
                words.ReplaceRandomWordWithUnderscores();
                Console.WriteLine("You did it!");
                }
        }

        else
        {
        string exit = "";
        while(exit != "exit")
        {
        words.PrintAsParagraph();
        exit = Console.ReadLine();
        Console.Clear();
        words.ReplaceRandomWordWithUnderscores();
        }
        Console.WriteLine("You did it!");
        }
        
    
}
}