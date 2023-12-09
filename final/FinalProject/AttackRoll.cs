class AttackModifierCalculator
{
    static int CallModifier(double cr,string size)

        {

            int proficiencyBonus = CalculateProficiencyBonus(cr);
            int abilityScoreModifier = CalculateAbilityScoreModifier(size);

            int attackModifier = abilityScoreModifier + proficiencyBonus;

            
            return(attackModifier);
        }


    static int CalculateProficiencyBonus(double cr)
    {
        if (cr < 5) return 2;
        else if (cr < 9) return 3;
        else if (cr < 13) return 4;
        else if (cr < 17) return 5;
        else return 6;
    }

    static int CalculateAbilityScoreModifier(string size)
    {
        switch (size.ToLower())
        {
            case "tiny":
                return -1;
            case "small":
                return 0;
            case "medium":
                return 2;
            case "large":
                return 3;
            case "huge":
                return 4;
            case "gargantuan":
                return 5;
            default:
                Console.WriteLine("Invalid size category. Assuming medium size.");
                return 2;
        }
    }

    public static int CalculateAttackRoll(Monster monster)
    {
        int proficiencyBonus = CalculateProficiencyBonus(monster.CRDecimal);
        int abilityScoreModifier = CalculateAbilityScoreModifier(monster.Size);

        int attackModifier = abilityScoreModifier + proficiencyBonus;

        // Roll a 20-sided dice

        DiceRoller diceRoller = new DiceRoller();
        int diceNumb = 1;
        int dicebig = 20;
        int diceRoll = DiceRoller.DiceRoll(dicebig,diceNumb);

        int AttackRollTotal = attackModifier + diceRoll;

        return AttackRollTotal;
    }

}