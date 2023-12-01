using System;

class Program
{
    static MonsterManager monsterManager;

    static void Main()
    {
        monsterManager = new MonsterManager("D&D_5e_Monster_Manual.csv");

        while (true)
        {
            Console.Clear(); // Clear the console

            Console.WriteLine("=====================================");
            Console.WriteLine("           Monster Menu               ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Call Random Monster");
            Console.WriteLine("2. Call Random Monster by CR");
            Console.WriteLine("3. Call Random Monster by Terrain");
            Console.WriteLine("4. Call Random Monster by CR and Terrain");
            Console.WriteLine("5. Search for a Specific Monster");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=====================================");

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CallRandomMonster();
                    break;
                case "2":
                    CallRandomMonsterByCR();
                    break;
                case "3":
                    CallRandomMonsterByTerrain();
                    break;
                case "4":
                    CallRandomMonsterByCRAndTerrain();
                    break;
                case "5":
                    SearchForSpecificMonster();
                    break;
                case "6":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine(); // Wait for Enter key
        }
    }

    static void CallRandomMonsterByTerrain()
    {
        Console.Write("Enter terrain (Arctic, Coast, Desert, Forest, Grassland, Hill, Mountain, Swamp, Underdark, Underwater, Urban): ");
        string terrainInput = Console.ReadLine();

        if (Enum.TryParse<TerrainType>(terrainInput, true, out TerrainType terrain))
        {
            Monster randomMonster = monsterManager.GetRandomMonsterByTerrain(terrain);

            if (randomMonster != null)
            {
                Console.WriteLine($"Summoning random monster in {terrain} terrain:");
                MonsterDisplay.DisplayMonsterInfo(randomMonster);
            }
        }
        else
        {
            Console.WriteLine("Invalid terrain. Please enter a valid terrain type.");
        }
    }

    static void CallRandomMonsterByCRAndTerrain()
    {
        Console.Write("Enter CR: ");
        if (double.TryParse(Console.ReadLine(), out double cr))
        {
            Console.Write("Enter terrain (Arctic, Coast, Desert, Forest, Grassland, Hill, Mountain, Swamp, Underdark, Underwater, Urban): ");
            string terrainInput = Console.ReadLine();

            if (Enum.TryParse<TerrainType>(terrainInput, true, out TerrainType terrain))
            {
                Monster randomMonster = monsterManager.GetRandomMonsterByCRAndTerrain(cr, terrain);

                if (randomMonster != null)
                {
                    Console.WriteLine($"Summoning random monster with CR {cr} in {terrain} terrain:");
                    MonsterDisplay.DisplayMonsterInfo(randomMonster);
                }
            }
            else
            {
                Console.WriteLine("Invalid terrain. Please enter a valid terrain type.");
            }
        }
        else
        {
            Console.WriteLine("Invalid CR. Please enter a valid number.");
        }
    }

    

    static void CallRandomMonster()
    {
        Monster randomMonster = monsterManager.GetRandomMonster();
        if (randomMonster != null)
        {
            Console.WriteLine("Summoning random monster:");
            MonsterDisplay.DisplayMonsterInfo(randomMonster);
        }
    }

    static void CallRandomMonsterByCR()
    {
        Console.Write("Enter CR: ");
    if (double.TryParse(Console.ReadLine(), out double cr))
    {
        Monster randomMonster = monsterManager.GetRandomMonsterByCR(cr);
        if (randomMonster != null)
        {
            Console.WriteLine($"Summoning random monster with CR {cr}:");
            MonsterDisplay.DisplayMonsterInfo(randomMonster);
        }
        else
        {
            Console.WriteLine($"No monsters found with CR {cr}.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input for CR. Please enter a valid number.");
    }
    }

    static void SearchForSpecificMonster()
    {
        Console.Write("Enter the name of the monster you are searching for: ");
        string monsterName = Console.ReadLine();

        Monster foundMonster = monsterManager.SearchMonsterByName(monsterName);

        if (foundMonster != null)
        {
            Console.WriteLine("Monster Found:");
            MonsterDisplay.DisplayMonsterInfo(foundMonster);
        }
        else
        {
            Console.WriteLine($"Monster '{monsterName}' not found.");
        }
    }
        
}
