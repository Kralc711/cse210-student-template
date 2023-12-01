using System;
using System.Windows;
using System.Media;

public class CustomSoundPlayer
{
    private readonly string filePath;

    public CustomSoundPlayer(string filePath)
    {
        this.filePath = filePath;
    }

    public void PlaySync()
    {
        try
        {
            SoundPlayer player = new SoundPlayer(filePath);
            player.PlaySync(); // Synchronously play the audio
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing WAV: {ex.Message}");
        }
        public SoundPlayer();
    }
}


// class Program
// {
//     static void Main()
//     {
//         CustomSoundPlayer soundPlayer = new CustomSoundPlayer("final\\FinalProject\\Never Gonna Give You Up - Rick Astley.wav");
//         soundPlayer.PlaySync();

//         Console.WriteLine("Press any key to exit...");
//         Console.ReadKey();
//     }
// }

