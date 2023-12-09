using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new();
        static int Score(List<Goal> goals) // Returns the score
        {
            int Score = 0;
                foreach (Goal goal in goals)
                {
                    Score += goal.GetTotalPoints();
                }
            return Score;
        }
        Console.WriteLine("Welcome to your Eternal Quest!");
//
        static void CharacterAnimate(int score)
        {
            CharacterGenerator GenerateCharacter = new CharacterGenerator();
            CharacterLevel levelCalculator = new CharacterLevel();

            
            levelCalculator.LevelUp(score);
            
            int calculatedLevel = levelCalculator.ReturnCharacterLevel();

            
            
            Console.WriteLine(GenerateCharacter.GenerateCharacter(calculatedLevel));
        }
        Console.WriteLine("Here is your character, level him up by completing tasks");
        
        CharacterAnimate(Score(goals));
        Thread.Sleep(3000);
        while (true)
        {
            
            Console.Clear();
            CharacterAnimate(Score(goals));
            Console.WriteLine("Menu\n1. Display Checklist\n2. Display Score\n3. Complete Goal\n4. Create New Goal\n5. Load up previous Goals\n6. Quit");
            string Input = Console.ReadLine();
            Console.Clear();            
            if (Input == "1")
            {
                int iteration = 0;
                foreach (Goal goal in goals)
                {
                    iteration += 1;
                    string check;
                    if (goal is SimpleGoal)
                    {
                        if (goal.GetCompleted() == 1)
                        {
                            check = "X";
                        }
                        else
                        {
                            check = " ";
                        }
                        Console.WriteLine($"{iteration}. {goal.GetGoalName()}: [{check}]");
                    }
                    else if (goal is FiniteGoal)
                    {
                        FiniteGoal finiteGoal = (FiniteGoal)goal;
                        if (finiteGoal.GetCompleted() / finiteGoal.GetRepeats() == 1)
                        {
                            check = "X";
                        }
                        else
                        {
                            check = $"{finiteGoal.GetRepeatTracker()}/{finiteGoal.GetRepeats()}";
                        }
                        Console.WriteLine($"{iteration}. {finiteGoal.GetGoalName()}: [{check}]");
                    }
                    else if (goal is EternalGoal)
                    {
                        EternalGoal eternalGoal = (EternalGoal)goal;
                        check = $"{eternalGoal.GetRepeatTracker()}";
                        Console.WriteLine($"{iteration}. {goal.GetGoalName()}: [{check}]");

                    }
                }
                Console.Write("Press ENTER to continue");
                Console.ReadLine();
                }
            else if (Input == "2")
            {
                foreach(Goal goal in goals)
                {
                    Console.WriteLine(goal.GetTotalPoints());
                }
                Console.WriteLine($"Score: {Score(goals)}");
                Console.ReadLine();
            }
            else if (Input == "3")
            {
                Console.Clear();
                Console.WriteLine("Which goal would you like to complete? ");
                int iteration = 0;
                foreach (Goal goal in goals)
                {
                    iteration += 1;
                    if (goal.GetCompleted() != 1)
                    {
                        Console.WriteLine($"{iteration}. {goal.GetGoalName()}: [{goal.GetGoalPoints()}]");
                    }
                }
                int choice = int.Parse(Console.ReadLine());
                goals[choice-1].Complete();
            }
            else if (Input == "4")
            {
                Console.Clear();
                Console.WriteLine("What type of goal are you creating?\n1. Simple one time goal\n2. Goal to be completed after a certain number of times\n3. Goal to do forever more\n4. Go back\n");
                string Input2 = Console.ReadLine();
                if (Input2 == "1")
                {
                    // Create Simple Goal
                    SimpleGoal simpleGoal = new();
                    simpleGoal.SetGoalType(1);
                    Console.Write("What do you want to call your goal: ");
                    string name = Console.ReadLine();
                    simpleGoal.SetGoalName(name);
                    Console.Write("Describe what your goal is: ");
                    string description = Console.ReadLine();
                    simpleGoal.SetGoalDescription(description);
                    Console.Write("How many points is your goal worth (int): ");
                    int points = int.Parse(Console.ReadLine());
                    simpleGoal.SetGoalPoints(points);
                    goals.Add(simpleGoal);
                }
                else if (Input2 == "2")
                {
                    // Create FiniteGoal
                    FiniteGoal finiteGoal = new();
                    finiteGoal.SetGoalType(2);
                    Console.Write("What do you want to call your goal: ");
                    string name = Console.ReadLine();
                    finiteGoal.SetGoalName(name);
                    Console.Write("Describe what your goal is: ");
                    string description = Console.ReadLine();
                    finiteGoal.SetGoalDescription(description);
                    Console.Write("How many points is your goal worth (int): ");
                    int points = int.Parse(Console.ReadLine());
                    finiteGoal.SetGoalPoints(points);
                    Console.Write("How many times do you want to repeat this goal: ");
                    int repeats = int.Parse(Console.ReadLine());
                    finiteGoal.SetRepeats(repeats);
                    goals.Add(finiteGoal);

                }
                else if (Input2 == "3")
                {
                    // Create EternalGoal
                    EternalGoal eternalGoal = new();
                    eternalGoal.SetGoalType(3);
                    Console.Write("What do you want to call your goal: ");
                    string name = Console.ReadLine();
                    eternalGoal.SetGoalName(name);
                    Console.Write("Describe what your goal is: ");
                    string description = Console.ReadLine();
                    eternalGoal.SetGoalDescription(description);
                    Console.Write("How many points is your goal worth (int): ");
                    int points = int.Parse(Console.ReadLine());
                    eternalGoal.SetGoalPoints(points);
                    goals.Add(eternalGoal);
                }
                else if (Input2 == "4")
                {
                }

            }
            else if (Input == "5")
            {
                Console.WriteLine("What is the filename of your goals? ");
                string filename = Console.ReadLine() + ".txt";

                string[] lines = System.IO.File.ReadAllLines(filename);
                foreach(string line in lines)
                {
                    string[] goal = line.Split(",");
                    if (goal[0] == "1")
                    {
                        SimpleGoal simpleGoal = new();
                        simpleGoal.SetGoalType(int.Parse(goal[0]));
                        simpleGoal.SetGoalName(goal[1]);
                        simpleGoal.SetGoalDescription(goal[2]);
                        simpleGoal.SetGoalPoints(int.Parse(goal[3]));
                        simpleGoal.SetGoalTotalPoints(int.Parse(goal[4]));
                        simpleGoal.AssignCompleted(int.Parse(goal[5]));
                        goals.Add(simpleGoal);
                    }
                    else if (goal[0] == "2")
                    {
                        FiniteGoal finiteGoal = new();
                        finiteGoal.SetGoalType(int.Parse(goal[0]));
                        finiteGoal.SetGoalName(goal[1]);
                        finiteGoal.SetGoalDescription(goal[2]);
                        finiteGoal.SetGoalPoints(int.Parse(goal[3]));
                        finiteGoal.SetGoalTotalPoints(int.Parse(goal[4]));
                        finiteGoal.AssignCompleted(int.Parse(goal[5]));
                        finiteGoal.SetRepeats(int.Parse(goal[6]));
                        finiteGoal.SetRepeatTracker(int.Parse(goal[7]));
                        goals.Add(finiteGoal);
                    }
                    else if (goal[0] == "3")
                    {
                        EternalGoal eternalGoal = new();
                        eternalGoal.SetGoalType(int.Parse(goal[0]));
                        eternalGoal.SetGoalName(goal[1]);
                        eternalGoal.SetGoalDescription(goal[2]);
                        eternalGoal.SetGoalPoints(int.Parse(goal[3]));
                        eternalGoal.SetGoalTotalPoints(int.Parse(goal[4]));
                        eternalGoal.AssignCompleted(int.Parse(goal[5]));
                        eternalGoal.SetRepeatTracker(int.Parse(goal[6]));
                        goals.Add(eternalGoal);
                    }

                }

            }
            else if (Input == "6")
            {
                Console.WriteLine("Want to save your goals for the future? (Y/N)");
                string yn = Console.ReadLine();
                if (yn.ToLower() == "y")
                {
                Console.WriteLine("What do you want to name your file (.txt)? " );
                string filename = Console.ReadLine() + ".txt";

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach(Goal goal in goals)
                    {
                        if (goal is SimpleGoal)
                        {
                            SimpleGoal simpleGoal = (SimpleGoal)goal;
                            int goalType = simpleGoal.GetGoalType();
                            string goalName = simpleGoal.GetGoalName();
                            string goalDescription = simpleGoal.GetGoalDescription();
                            int goalPoints = simpleGoal.GetGoalPoints();
                            int totalPoints = simpleGoal.GetTotalPoints();
                            int completed = simpleGoal.GetCompleted();
                            
                            outputFile.WriteLine($"{goalType},{goalName},{goalDescription},{goalPoints},{totalPoints},{completed}");
                        }
                        else if (goal is FiniteGoal)
                        {
                            FiniteGoal finiteGoal = (FiniteGoal)goal;
                            int goalType = finiteGoal.GetGoalType();
                            string goalName = finiteGoal.GetGoalName();
                            string goalDescription = finiteGoal.GetGoalDescription();
                            int goalPoints = finiteGoal.GetGoalPoints();
                            int totalPoints = finiteGoal.GetTotalPoints();
                            int completed = finiteGoal.GetCompleted();
                            int repeats = finiteGoal.GetRepeats();
                            int repeattracker = finiteGoal.GetRepeatTracker();
                            
                            outputFile.WriteLine($"{goalType},{goalName},{goalDescription},{goalPoints},{totalPoints},{completed},{repeats},{repeattracker}");
                        }
                        else if (goal is EternalGoal)
                        {
                            EternalGoal eternalGoal = (EternalGoal)goal;
                            int goalType = eternalGoal.GetGoalType();
                            string goalName = eternalGoal.GetGoalName();
                            string goalDescription = eternalGoal.GetGoalDescription();
                            int goalPoints = eternalGoal.GetGoalPoints();
                            int totalPoints = eternalGoal.GetTotalPoints();
                            int completed = eternalGoal.GetCompleted();
                            int repeattracker = eternalGoal.GetRepeatTracker();
                            
                            outputFile.WriteLine($"{goalType},{goalName},{goalDescription},{goalPoints},{totalPoints},{completed},{repeattracker}");
                        }


                    }
                }
                }
                break;
            }
        }
    }
}