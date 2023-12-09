using System;

class CharacterGenerator
{
    private string[] asciiArtArray = {
        // Acolyte - Level 1
        "   ~   \n  /|\\  \n  / \\  ",
        
        // Acolyte - Level 2
        "   @   \n  /|\\  \n  / \\  ",
        
        // Acolyte - Level 3
        "   #   \n  /|\\  \n  / \\  "
        // Add more levels as needed
    };

    // Generate ASCII art for a character at a specific level
    public string GenerateCharacter(int level)
    {
        // Ensure the requested level is within the array bounds
        if (level > 0 && level <= asciiArtArray.Length)
        {
            return asciiArtArray[level - 1];
        }
        else
        {
            return "Please purchase full version to access high level characters.";
        }
    }
}
