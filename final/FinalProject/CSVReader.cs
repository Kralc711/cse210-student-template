using System;
using System.Collections.Generic;
using System.IO;

public static class MonsterCsvReader
{
    public static List<Monster> ReadMonstersFromCsv(string filePath)
    {
        List<Monster> monsters = new List<Monster>();

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found - {filePath}");
                return monsters;
            }

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // Skip header
            {
                try
                {
                    var values = SplitCsvLine(line);

                    monsters.Add(new Monster
                    {
                        Name = values[0],
                        Type = values[1],
                        Alignment = values[2],
                        Size = values[3],
                        CRDecimal = Convert.ToDouble(values[4]),
                        AC = Convert.ToInt32(values[5]),
                        HP = Convert.ToInt32(values[6]),
                        Spellcasting = values[7].Equals("YES", StringComparison.OrdinalIgnoreCase),
                        Attack1Damage = values[8],
                        Attack2Damage = values[9],
                        Page = Convert.ToInt32(values[10]),
                        Arctic = ParseBooleanValue(values[11]),
                        Coast = ParseBooleanValue(values[12]),
                        Desert = ParseBooleanValue(values[13]),
                        Forest = ParseBooleanValue(values[14]),
                        Grassland = ParseBooleanValue(values[15]),
                        Hill = ParseBooleanValue(values[16]),
                        Mountain = ParseBooleanValue(values[17]),
                        Swamp = ParseBooleanValue(values[18]),
                        Underdark = ParseBooleanValue(values[19]),
                        Underwater = ParseBooleanValue(values[20]),
                        Urban = ParseBooleanValue(values[21]),
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing line: {line}");
                    Console.WriteLine($"Error details: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }

        return monsters;
    }

    private static bool ParseBooleanValue(string value)
    {
        return string.Equals(value.Trim('"', ' '), "YES", StringComparison.OrdinalIgnoreCase);
    }

    private static string[] SplitCsvLine(string line)
    {
        var values = new List<string>();
        var currentField = "";
        var insideQuotes = false;

        foreach (var c in line)
        {
            if (c == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                values.Add(currentField.Trim(' ', '"'));
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }

        values.Add(currentField.Trim(' ', '"'));

        return values.ToArray();
    }
}
