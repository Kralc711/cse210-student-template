using System;
using NAudio.Wave;

class Program
{
    static void Main()
    {
        // Replace "path_to_your_audio_file.wav" with the actual path to your audio file
        string audioFilePath = "C:\\School\\ProgrammingClasses\\cse210-student-template\\final\\Foundation1\\Program.cs";

        try
        {
            // Create a WaveOutEvent instance
            using (var waveOut = new WaveOutEvent())
            {
                // Create a WaveFileReader with the audio file path
                using (var audioFileReader = new AudioFileReader(audioFilePath))
                {
                    // Add the WaveFileReader to the WaveOutEvent
                    waveOut.Init(audioFileReader);

                    // Start playing the audio
                    waveOut.Play();

                    // You might want to add a delay or perform other tasks here while the audio is playing
                    Console.WriteLine("Press any key to stop the audio...");
                    Console.ReadKey();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
