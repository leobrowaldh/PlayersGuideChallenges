using System.Reflection.Metadata;

namespace Hunting_the_Manticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int manticorePosition = ManticorePosition();
            Game(manticorePosition);
        }

        static int ManticorePosition()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        static void Game(int manticorePosition)
        {
            //Initial state:
            int cityHealth = 15;
            int manticoreHealth = 10;
            int round = 1;
            //The gameloop that will go on until one of them is dead:
            while (cityHealth > 0 && manticoreHealth > 0)
            {
                Console.WriteLine($"STATUS: Round {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
                int cannonDamage = CannonDamage(round);
                Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
                int cannonRange;
                bool correctInput;
                //make sure the user input correctly a range for the cannon:
                do
                {
                    Console.Write("Enter desired cannon range: ");
                    string userInput = Console.ReadLine();
                    correctInput = int.TryParse(userInput, out cannonRange);
                    if (!correctInput)
                    {
                        Console.WriteLine("---wrong input, enter a non-decimal number between 1 and 100---");
                    }
                }
                while (!correctInput);
                //make the shot and se if it is a hit:
                manticoreHealth = Shoot(cannonRange, manticorePosition, manticoreHealth, cannonDamage);
                //If allive, the Manticore attacks the city.
                if (manticoreHealth > 0) { cityHealth -= 1; }
                round++;
            }
            //the endgame:
            if (cityHealth < 1) 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You city is in ashes, you have failed."); 
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("The Manticore have been destroyed! Consolas have been saved!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static int CannonDamage(int round)
        {
            if (round % 3 == 0 && round % 5 == 0) { return 10; }
            else if (round % 3 == 0 || round % 5 == 0) { return 3; }
            else { return 1; }
        }

        static int Shoot (int cannonRange, int manticorePosition, int manticoreHealth, int cannonDamage)
        {
            if (cannonRange == manticorePosition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("That round was a DIRECT HIT!");
                Console.ResetColor();
                manticoreHealth -= cannonDamage;
            }
            else if (cannonRange < manticorePosition)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round FELL SHORT of the target.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That round OVERSHOT the target.");
                Console.ResetColor();
            }
            Console.WriteLine();
            return manticoreHealth;
        }
    }
}
/*
 static void PrintColoredText(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

// Usage
if (condition)
{
    PrintColoredText("This text is red.", ConsoleColor.Red);
}

 */ 