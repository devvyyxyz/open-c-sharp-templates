using System;

using System.Threading;



class Program

{

    static void Main()

    {

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Welcome to Epic RPG!");

        Console.WriteLine("----------");

        Console.WriteLine("Get started!");

        Console.ResetColor();



        Console.Write("Enter your character's name: ");

        string? playerName = Console.ReadLine();



        Console.Write("Enter your character's description: ");

        string? playerDesc = Console.ReadLine();



        Console.BackgroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("1. Speed");

        Console.WriteLine("2. Strength");

        Console.ResetColor();

        Console.Write("Pick your character's trait: ");



        if (int.TryParse(Console.ReadLine(), out int playerTrait))

        {

            switch (playerTrait)

            {

                case 1:

                    //  

                    Console.WriteLine("You have chosen speed this will grant you the benefit of a 75% chance to run away from an encounter");

                    break;

                case 2:

                    //  

                    Console.WriteLine("You have chosen strength this will grant you the benefit of extra damage!");

                    break;

            }

        }

        else

        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Invalid input. Try again.");

            Console.ResetColor();

        }



        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("Loading...");

        Console.ResetColor();

        Thread.Sleep(5000);



        // Create a character 

        Character player = new Character(playerName, 100, 10);



        // Create an enemy 

        Character enemy = new Character("Evil Goblin", 50, 5);



        Console.Write("\nYou encounter ");

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write("Evil Goblin!");

        Console.ResetColor();

        Console.WriteLine("\n----------");



        // Game loop 

        while (player.IsAlive && enemy.IsAlive)

        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write($"\n{player.Name}'s ");

            Console.ResetColor();

            Console.Write("HP: ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{player.Health}\n");

            Console.ResetColor();



            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"{enemy.Name}'s ");

            Console.ResetColor();

            Console.Write("HP: ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{enemy.Health}\n");

            Console.ResetColor();



            Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("1. Attack");

            Console.WriteLine("2. Run");

            Console.ResetColor();

            Console.Write("Choose your action: ");



            if (int.TryParse(Console.ReadLine(), out int choice))

            {

                switch (choice)

                {

                    case 1:

                        // Player attacks enemy 

                        int damageToEnemy = player.Attack();

                        Console.Write($"\n{player.Name} attacks {enemy.Name} for ");

                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.Write($"{damageToEnemy} damage!");

                        Console.ResetColor();

                        enemy.TakeDamage(damageToEnemy);



                        // Enemy attacks player 

                        int damageToPlayer = enemy.Attack();

                        Console.Write($"\n{enemy.Name} attacks {player.Name} for ");

                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.Write($"{damageToPlayer} damage!");

                        Console.ResetColor();

                        player.TakeDamage(damageToPlayer);

                        break;

                    case 2:

                        // Player tries to run 

                        if (playerTrait == 1)

                        {

                            Console.WriteLine($"{player.Name} successfully escapes!!!!!!!");

                            return;

                        }

                        else

                            if (RandomGenerator.Next(2) == 0)

                        {

                            Console.WriteLine($"{player.Name} successfully escapes!");

                            return;

                        }

                        else

                        {

                            Console.WriteLine($"{player.Name} failed to escape!", ConsoleColor.Red);

                        }

                        break;

                    default:

                        Console.WriteLine("Invalid choice. Try again.", ConsoleColor.Yellow);

                        break;

                }

            }

            else

            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Invalid input. Try again.");

                Console.ResetColor();

            }



            Thread.Sleep(5000); // Pause for readability 

        }



        if (player.IsAlive)

        {

            Console.WriteLine($"Congratulations, {player.Name}! You defeated the Evil Goblin!", ConsoleColor.Green);

        }

        else

        {

            Console.WriteLine($"{player.Name} has been defeated by the Evil Goblin. Game over!", ConsoleColor.Red);

        }

    }

}



class Character

{

    public string Name { get; private set; }

    public int Health { get; private set; }

    public int Damage { get; private set; }

    public bool IsAlive => Health > 0;



    public Character(string name, int health, int damage)

    {

        Name = name;

        Health = health;

        Damage = damage;

    }



    public int Attack()

    {

        return RandomGenerator.Next(Damage / 2, Damage + 1);

    }



    public void TakeDamage(int damage)

    {

        Health -= damage;

        if (Health < 0)

        {

            Health = 0;

        }

    }

}



static class RandomGenerator

{

    private static Random random = new Random();



    public static int Next(int minValue, int maxValue)

    {

        return random.Next(minValue, maxValue);

    }



    public static int Next(int maxValue)

    {

        return random.Next(maxValue);

    }

}



static class ConsoleExtensions

{

    public static void WriteLine(string message, ConsoleColor color)

    {

        Console.ForegroundColor = color;

        Console.WriteLine(message);

        Console.ResetColor();

    }

}

