class Program
{
    static void Main()
    {
        MonsterManager monsterManager = new MonsterManager("your_file_path.csv");

        // Example: Search for a monster by name
        Console.Write("Enter the name of the monster to search: ");
        string searchName = Console.ReadLine();
        Monster searchedMonster = monsterManager.SearchMonsterByName(searchName);

        if (searchedMonster != null)
        {
            Console.WriteLine($"Monster found: {searchedMonster}");
        }
        else
        {
            Console.WriteLine("Monster not found.");
        }

        // Example: Get a random monster based on terrain
        Console.Write("Enter the terrain to get a random monster: ");
        string terrain = Console.ReadLine();
        Monster randomMonster = monsterManager.GetRandomMonsterByTerrain(terrain);

        if (randomMonster != null)
        {
            Console.WriteLine($"Random monster for {terrain}: {randomMonster}");
        }
    }
}
