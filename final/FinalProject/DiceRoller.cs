using System;
using System.Collections.Generic;

class DiceRoller
{
    static Dictionary<string, int> damages = new Dictionary<string, int>
    {
        {"Acid", 0},
        {"Bludgeoning", 0},
        {"Cold", 0},
        {"Fire", 0},
        {"Force", 0},
        {"Lightning", 0},
        {"Necrotic", 0},
        {"Piercing", 0},
        {"Poison", 0},
        {"Psychic", 0},
        {"Radiant", 0},
        {"Slashing", 0},
        {"Thunder", 0},
    };

    // static void Main()
    // {
    //     Console.Write("How many damage instances would you like to roll? ");
    //     int runGoal = int.Parse(Console.ReadLine());

    //     int runCount = 0;
    //     while (runCount < runGoal)
    //     {
    //         Console.Write("How many sides? ");
    //         int diceSides = int.Parse(Console.ReadLine());

    //         Console.Write("How many dice? ");
    //         int diceCount = int.Parse(Console.ReadLine());

    //         Console.Write("What kind of damage? ");
    //         string damageType = Console.ReadLine().CapitalizeFirstLetter();
            
    //         runCount += DiceRoll(diceSides, diceCount, damageType);
    //     }

    //     PrintTotal();
    // }

    static void PrintTotal()
    {
        foreach (var damage in damages)
        {
            if (damage.Value > 0)
            {
                int save1 = ResistanceOrSave(damage.Value);
                int save2 = ResistanceAndSave(damage.Value);
                Console.WriteLine($"{damage.Value} {damage.Key} damage: {save1} if resistant or successful save, {save2} if both");
            }
        }
    }

    static int DiceRoll(int diceSides, int diceCount, string damageType)
    {
        Random random = new Random();
        int roll = 0;

        for (int i = 0; i < diceCount; i++)
        {
            roll += random.Next(1, diceSides + 1);
        }

        damages[damageType] += roll;
        return 1;
    }

    static int ResistanceOrSave(int damage)
    {
        float save = damage / 2;
        return (int)Math.Round(save);
    }

    static int ResistanceAndSave(int damage)
    {
        float saveAnd = damage / 4;
        return (int)Math.Round(saveAnd);
    }
}

public static class StringExtensions
{
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
