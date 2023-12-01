using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public class MonsterManager
{
    private List<Monster> monsters;

    public MonsterManager(string filePath)
    {
        monsters = MonsterCsvReader.ReadMonstersFromCsv(filePath);
    }

    public Monster SearchMonsterByName(string name)
    {
        return monsters.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Monster GetRandomMonster()
    {
        Random random = new Random();
        int randomIndex = random.Next(monsters.Count);
        return monsters[randomIndex];
    }

    public Monster GetRandomMonsterByTerrain(TerrainType terrain)
    {
        var matchingMonsters = monsters
            .Where(m => m.MatchTerrain(terrain))
            .ToList();

        return GetRandomMonsterFromList(matchingMonsters);
    }

    public Monster GetRandomMonsterByCRAndTerrain(double cr, TerrainType terrain)
    {
        var matchingMonsters = monsters
            .Where(m => m.CRDecimal == cr && m.MatchTerrain(terrain))
            .ToList();

        return GetRandomMonsterFromList(matchingMonsters);
    }

    public Monster GetRandomMonsterByCR(double cr)
    {
        var matchingMonsters = monsters
            .Where(m => m.CRDecimal == cr)
            .ToList();

        return GetRandomMonsterFromList(matchingMonsters, $"No monsters found with CR {cr}.");
    }

    private Monster GetRandomMonsterFromList(List<Monster> monsterList, string noMonsterMessage = "No monsters found.")
    {
        if (monsterList.Count == 0)
        {
            Console.WriteLine(noMonsterMessage);
            return null;
        }

        Random random = new Random();
        int randomIndex = random.Next(monsterList.Count);
        return monsterList[randomIndex];
    }
}
