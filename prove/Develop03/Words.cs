
public class Words
{
    private List<string> scriptureWords;
    private Random random;

    public Words()
    {
        // Initialize the list of scripture words and the Random object in the constructor
        scriptureWords = new List<string>();
        random = new Random();
    }

    public void AddWord(string inputString)
    {
        string[] wordsArray = inputString.Split(' ');

        // Add the words to the list
        foreach (string word in wordsArray)
        {
            scriptureWords.Add(word);
        }
    }

    public List<string> GetScriptureWords()
    {
        // Return the list of scripture words
        return scriptureWords;
    }

    public void PrintAsParagraph()
    {
        // Print the list of words as a paragraph
        Console.WriteLine(string.Join(" ", scriptureWords));
    }

    public void ReplaceRandomWordWithUnderscores()
    {
        // Check if there are words in the list
        if (scriptureWords.Count > 0)
        {
            // Generate a random index to select a word from the list
            int randomIndex = random.Next(scriptureWords.Count);

            // Replace the randomly selected word with underscores
            string randomWord = scriptureWords[randomIndex];
            string underscoreWord = new string('_', randomWord.Length);
            scriptureWords[randomIndex] = underscoreWord;
        }
    }
}