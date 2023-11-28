using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Monster
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public double CRDecimal { get; set; }
    public int AC { get; set; }
    public int HP { get; set; }
    public bool Spellcasting { get; set; }
    public string Attack1Damage { get; set; }
    public string Attack2Damage { get; set; }
    public int Page { get; set; }
    public bool Arctic { get; set; }
    public bool Coast { get; set; }
    public bool Desert { get; set; }
    public bool Forest { get; set; }
    public bool Grassland { get; set; }
    public bool Hill { get; set; }
    public bool Mountain { get; set; }
    public bool Swamp { get; set; }
    public bool Underdark { get; set; }
    public bool Underwater { get; set; }
    public bool Urban { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Type}, {Alignment}, {Size}, {CRDecimal}, {AC}, {HP}, {Spellcasting}, {Attack1Damage}, {Attack2Damage}, {Page}, {Arctic}, {Coast}, {Desert}, {Forest}, {Grassland}, {Hill}, {Mountain}, {Swamp}, {Underdark}, {Underwater}, {Urban}";
    }
}

class MonsterManager
{
    private List<Monster> monsters;

    public MonsterManager(string filePath)
    {
        monsters = ReadMonstersFromCsv(filePath);
    }

    public List<Monster> ReadMonstersFromCsv(string filePath)
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

    public Monster SearchMonsterByName(string name)
    {
        return monsters.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Monster GetRandomMonsterByTerrain(string terrain)
    {
        var terrainProperty = typeof(Monster).GetProperty(terrain, StringComparison.OrdinalIgnoreCase);

        if (terrainProperty == null || terrainProperty.PropertyType != typeof(bool))
        {
            Console.WriteLine("Invalid terrain property.");
            return null;
        }

        var matchingMonsters = monsters.Where(m => (bool)terrainProperty.GetValue(m)).ToList();

        if (matchingMonsters.Count == 0)
        {
            Console.WriteLine("No monsters found for the specified terrain.");
            return null;
        }

        Random random = new Random();
        int randomIndex = random.Next(matchingMonsters.Count);
        return matchingMonsters[randomIndex];
    }
}
