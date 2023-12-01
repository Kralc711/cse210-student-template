using System;

public class MonsterDisplay
{
    public static void DisplayMonsterInfo(Monster monster)
    {
        
        StatBox(monster);

        Console.Write("Do you want to find another monster (F) or fight this monster (C)? ");
        string actionChoice = Console.ReadLine();

        if (actionChoice.Equals("F", StringComparison.OrdinalIgnoreCase))
        {
            // User wants to find another monster
            return;
        }
        else if (actionChoice.Equals("C", StringComparison.OrdinalIgnoreCase))
        {
            // User wants to fight the monster
            Combat combat = new Combat(monster);
            combat.StartCombat(monster);
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to the main menu.");
        }
    }

    public static void StatBox(Monster monster)
    {
       Console.WriteLine("=========================================");
        Console.WriteLine($"               {monster.Name}               ");
        Console.WriteLine("=========================================");
        Console.WriteLine($"Type:          {monster.Type}");
        Console.WriteLine($"Alignment:     {monster.Alignment}");
        Console.WriteLine($"Size:          {monster.Size}");
        Console.WriteLine($"CR:            {monster.CRDecimal}");
        Console.WriteLine($"AC:            {monster.AC}");
        Console.WriteLine($"HP:            {monster.HP}");
        Console.WriteLine($"Spellcasting:  {monster.Spellcasting}");
        Console.WriteLine($"Attack 1 Dmg:  {monster.Attack1Damage}");
        Console.WriteLine($"Attack 2 Dmg:  {monster.Attack2Damage}");
        Console.WriteLine($"Page:          {monster.Page}");
        Console.WriteLine("=========================================");
        Console.WriteLine(); 
    }

    }

