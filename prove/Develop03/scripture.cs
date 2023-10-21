using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

class Scripture
{
    public string ScriptureCaller(string book, int chapter, int verse)
    {
        string lineReturn = ""; // Define the variable outside the loop

        using (TextFieldParser parser = new TextFieldParser("lds-scriptures.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] line = parser.ReadFields();

                if (line[5].Equals(book, StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(line[14], out int chaptercheck) && chaptercheck == chapter &&
                    int.TryParse(line[15], out int versecheck) && versecheck == verse)
                {
                    // Extract words from the matching line and add them to the Words class
                    // foreach (string word in line[16].Split(' '))
                    // {
                    // }
                    lineReturn = line[16]; // Set the value of lineReturn inside the loop
                    break; // Break the loop once a match is found
                }
            }
        }

        return lineReturn; // Return the scripture text (or an empty string if no match is found)
    }
}