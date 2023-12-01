using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class MonsterCsvReader
{
    public static List<Monster> ReadMonstersFromCsv(string filePath)
    {
        List<Monster> monsters = new List<Monster>();

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // Skip header
            {
                var values = line.Split(',');

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
                    Arctic = values[11].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Coast = values[12].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Desert = values[13].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Forest = values[14].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Grassland = values[15].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Hill = values[16].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Mountain = values[17].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Swamp = values[18].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Underdark = values[19].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Underwater = values[20].Equals("YES", StringComparison.OrdinalIgnoreCase),
                    Urban = values[21].Equals("YES", StringComparison.OrdinalIgnoreCase),
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
        }

        return monsters;
    }
}
