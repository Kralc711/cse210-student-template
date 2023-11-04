public abstract class Activity
{
    public string Name { get; }
    public string Description { get; }
    public int Duration { get; private set; }

    protected Activity(string name, string description, int duration)
    {
        Name = name;
        Description = description;
        Duration = duration;
    }

    public void SetDuration(int duration)
    {
        Duration = duration;
    }

    public void ShowStartingMessage()
    {
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.WriteLine($"Duration: {Duration} seconds");
        Thread.Sleep(2000);
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000);
    }

    public void ShowEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {Name} for {Duration} seconds.");
        Thread.Sleep(2000);
    }

    public abstract void StartActivity();

    public void LoadingBar(int BarLength)
    {
        {
        Console.Write("[");
        int progressBarLength = Console.WindowWidth - 14; // Calculate the length of the progress bar
        int sleepDuration = BarLength * 1000 / progressBarLength; // Calculate the sleep duration per segment
        
        for (int i = 0; i < progressBarLength; i++)
        {
            Console.Write("▓"); // Print a segment of the loading bar
            Thread.Sleep(sleepDuration); // Wait for a short duration
        }

        Console.WriteLine("]");
    }
        
        
        // string bar = "░";
        // while(bar.Length < BarLength*50)
        // {
        //     bar = bar + "░";
        // }

        // Random random = new Random();
        // Console.WriteLine("Loading: ["+bar+"]"); // Print the current string
        // for (int i = 0; i < bar.Length; i++)
        // {
            
        //     bar = bar.Remove(bar.LastIndexOf('░'), 1).Insert(0, "▓"); // Replace one '+' with '-'

        //     // Generate a random wait time with mean of 1.5 seconds and standard deviation of 0.5 seconds
        //     double mean = 0.01; // mean in seconds
        //     double stdDev = 0.05; // standard deviation in seconds

        //     // Generate a random number from a normal distribution with mean and standard deviation
        //     double delay = Math.Max(0, random.NextGaussian(mean, stdDev));

        //     int milliseconds = (int)(delay * 1000); // Convert seconds to milliseconds

        //     System.Threading.Thread.Sleep(milliseconds); // Add a random delay to slow down the output

        //     Console.Clear(); // Clear the console
        //     Console.WriteLine("Loading: ["+bar+"]"); // Print the current string
        // }
        // Console.Clear(); // Clear the console
        
    }
}

