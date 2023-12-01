public class Combat
{
    private Monster monster;
    private int monsterCurrentHealth;

    public Combat(Monster monster)
    {
        this.monster = monster;
        this.monsterCurrentHealth = monster.HP; // Initialize monster's current health
    }

    public void StartCombat(Monster monster)
    {
        Console.WriteLine($"Entering combat with {monster.Name}!");

        // Determine who goes first
        bool partyGoesFirst = DetermineFirstTurn();

        while (true)
        {
            if (partyGoesFirst)
            {
                PartyTurn();
                if (monsterCurrentHealth <= 0)
                {
                    Console.WriteLine($"Party defeated {monster.Name}!");
                    break; // Combat ends if the monster is defeated
                }

                MonsterTurn();
                if (monsterCurrentHealth <= 0)
                {
                    Console.WriteLine($"Party defeated! {monster.Name} wins!");
                    break; // Combat ends if the party is defeated
                }
            }
            else
            {
                MonsterTurn();
                if (monsterCurrentHealth <= 0)
                {
                    Console.WriteLine($"Party defeated! {monster.Name} wins!");
                    break; // Combat ends if the party is defeated
                }

                PartyTurn();
                if (monsterCurrentHealth <= 0)
                {
                    Console.WriteLine($"Party defeated {monster.Name}!");
                    break; // Combat ends if the monster is defeated
                }
            }
        }

        Console.WriteLine("Combat has ended!");
    }

    private bool DetermineFirstTurn()
    {
        Random random = new Random();
        return random.Next(2) == 0; // 0 represents party goes first, 1 represents monster goes first
    }

    private void PartyTurn()
    {
        Console.WriteLine("Party's Turn:");

        // Display party options
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Run Away");
        Console.WriteLine("3. End Turn");

        Console.Write("Choose your action (1-3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                int damageDealt = PartyAttack();
                Console.WriteLine($"Party dealt {damageDealt} damage to {monster.Name}!");
                break;
            case "2":
                Console.WriteLine("Party runs away!");
                monsterCurrentHealth = 0; // Set monster health to 0 to end combat
                break;
            case "3":
                Console.WriteLine("Party ends their turn.");
                break;
            default:
                Console.WriteLine("Invalid choice. Party ends their turn.");
                break;
        }
    }

    private int PartyAttack()
    {
        Console.Write("Enter the damage dealt by the party: ");
        int damageDealt = int.Parse(Console.ReadLine());

        // Update monster's health
        monsterCurrentHealth -= damageDealt;

        // Print monster's current health
        Console.WriteLine($"{monster.Name}'s current health: {monsterCurrentHealth}");

        return damageDealt;
    }

    private void MonsterTurn()
    {
        Console.WriteLine($"{monster.Name}'s Turn:");

        // Monster attacks with its two attacks (if available)
        if(monster.Attack2Damage != "N/A")
        {
            AttackModifierCalculator attackModifierCalculator = new AttackModifierCalculator();

            int ToHit = AttackModifierCalculator.CalculateAttackRoll(this.monster);

        int damage = ParseAndRollAttackDamage(monster.Attack1Damage);
        Console.WriteLine($"{monster.Name} attacks with its first attack, {ToHit} to hit, dealing {damage} damage!");
        }
        else
        {
        AttackModifierCalculator attackModifierCalculator = new AttackModifierCalculator();

            int ToHit = AttackModifierCalculator.CalculateAttackRoll(this.monster);

        int damage = ParseAndRollAttackDamage(monster.Attack1Damage);
        Console.WriteLine($"{monster.Name} attacks with its first attack, {ToHit} to hit, dealing {damage} damage!");
        }
        if(monster.Attack2Damage != "N/A")
        {AttackModifierCalculator attackModifierCalculator = new AttackModifierCalculator();

            int ToHit = AttackModifierCalculator.CalculateAttackRoll(this.monster);

        int damage = ParseAndRollAttackDamage(monster.Attack2Damage);
        Console.WriteLine($"{monster.Name} attacks with its first attack, {ToHit} to hit, dealing {damage} damage!");
        }
    }

    private int ParseAndRollAttackDamage(string attackDamage)
    {
        try
        {
            var (numberOfDice, diceSize, damageModifier) = ParseDiceInput(attackDamage);
            return DiceRoller.DiceRoll(diceSize, numberOfDice) + damageModifier;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error parsing attack damage: {ex.Message}");
            return 0;
        }
    }

    public static (int, int, int) ParseDiceInput(string input)
    {
        // Example input: "2d6+3"
        string[] parts = input.ToLower().Split('d');

        if (parts.Length == 2)
        {
            int numberOfDice = int.Parse(parts[0]);
            int diceSize;

            // Check if there is a modifier (e.g., +3)
            string[] modifierParts = parts[1].Split('+');
            if (modifierParts.Length == 2)
            {
                diceSize = int.Parse(modifierParts[0]);
                int modifier = int.Parse(modifierParts[1]);
                return (numberOfDice, diceSize, modifier);
            }
            else
            {
                
                diceSize = int.Parse(parts[1]);
                return (numberOfDice, diceSize, 0);
            }
        }

        throw new ArgumentException("Invalid dice input format. Use the format 'XdY+Z'.");
    }

    
}
