using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Monster> monsters = MonsterCsvReader.ReadMonstersFromCsv("D&D_5e_Monster_Manual.csv");

        // Example: Print the details of each monster
        foreach (var monster in monsters)
        {
            Console.WriteLine(monster);
        }
    }
}
