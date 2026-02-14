/*
Goal:
Practice loops, input handling, and randomness in a tension-based mini-game.

Scenario:
You’re trapped in a dark dungeon. A monster is chasing you.
Each turn, you can:
	1.	Run (try to escape)
	2.	Hide (reduce risk but waste time)
	3.	Fight (risky — but might defeat the monster)

You must survive until you either escape successfully or die trying.

Rules:
    Player starts with 20 HP.
        •	Monster starts with 15 HP.
        •	Use a Random object to decide outcomes.
        •	Each turn, the player chooses one of the three actions:

    1. Run
        •	50% chance to escape successfully → you win.
        •	50% chance you stumble and lose 3 HP.

    2. Hide
        •	70% chance the monster doesn’t find you → nothing happens.
        •	30% chance the monster spots and bites you for 5 damage.

    3. Fight
        •	You attack first: deal 4–8 random damage.
        •	If the monster survives, it counterattacks for 2–6 damage.

    After each turn, print both HP values.
    The game continues until:
        •	Player HP ≤ 0 → “You were slain!”
        •	Monster HP ≤ 0 → “You defeated the monster!”
        •	Player escapes → “You escaped the dungeon alive!”

Bonus challenge (optional)
Add a dramatic 1-second pause (Thread.Sleep(1000)) between turns,
and display a summary like: “You survived for X turns.”
*/
public class DailyEx004MonsterEscape
{
    public static void RunApp()
    {

        // Game greeting
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("MONSTER ESCAPE V1.0 >:(");
        Console.WriteLine("------------------------------------------------------------");

        // 1: Define variables
        Random chances = new();
        int playerLife = 20;
        int monsterLife = 15;
        bool playerEscaped = false;
        string? userInput;
        int turnsSurvived = 0;
        bool playAgain = true;
        string? replayAnswer;

        Console.WriteLine("You are trapped in a dark dungeon. A monster is chasing you.");
        do
        {
            while (playerLife > 0 && monsterLife > 0 && !playerEscaped)
            {
                do
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Choose action:\n\n1 - Run (try to escape)\n2 - Hide (reduce risk but waste time)\n3 - Fight (risky - but might kill it)");
                    Console.WriteLine("------------------------------------------------------------");
                    userInput = Console.ReadLine()?.Trim();   
                } while (userInput != "1" && userInput != "2" && userInput != "3");

                // You must survive until you either escape successfully or die trying.
                switch (userInput)
                {
                    case "1":
                        int chancesCap = 30;
                        int escapeOutcome = chances.Next(0, chancesCap);
                        Console.WriteLine($"You choose to run");
                        if (escapeOutcome >= 20)
                        {
                            playerEscaped = true;
                        }
                        else
                        {
                            playerEscaped = false;
                            playerLife -= 3;
                            Console.WriteLine("You stumbled. You lost 3 hp!");
                        }
                        break;
                    case "2":
                        int hidingCap = 10;                        
                        int hidingOutcome = chances.Next(0, hidingCap);
                        Console.WriteLine($"You choose to hide");
                        if (hidingOutcome >= 7)
                        {
                            playerLife -= 5;
                            Console.WriteLine("The monster found you and bit you. You lose 5 hp");                        
                        }
                        else
                        {
                            Console.WriteLine("You hid successfully. Catch some rest.");
                        }
                        break;
                    case "3":                        
                        int playerAttack = chances.Next(4, 9);
                        int monsterAttack = chances.Next(2, 7);
                        Console.WriteLine($"You to attack the monster and deal {playerAttack} dmg");
                        monsterLife -= playerAttack;
                        if (monsterLife > 0)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"Monster attacks back to you and deals {monsterAttack} dmg");
                            playerLife -= monsterAttack;   
                        }                
                        break;
                }
                
                if (playerLife < 0) playerLife = 0;
                if (monsterLife < 0) monsterLife = 0;
                Console.WriteLine($"Player life -- {playerLife}");
                Console.WriteLine($"Monster life -- {monsterLife}");
                Console.WriteLine("------------------------------------------------------------");
                turnsSurvived++;
                Thread.Sleep(1000);
            }

            if (playerLife <= 0)
            {
                Console.WriteLine("YOU DIED");
            }
            else if (monsterLife <= 0)
            {
                Console.WriteLine("ENEMY FELLED");
            }
            else if (playerEscaped)
            {
                Console.WriteLine("YOU ESCAPED THE DUNGEON ALIVE");
            }  

            Console.WriteLine($"Turns survived: {turnsSurvived}");
            Console.WriteLine("------------------------------------------------------------");

            do
            {
                Console.WriteLine("Play again?\n\n1 - Yes\n2 -  No");
                replayAnswer = Console.ReadLine()?.Trim();

                if (replayAnswer == "1")
                {
                    playAgain = true;
                    playerLife = 20;
                    monsterLife = 15;
                    playerEscaped = false;
                    turnsSurvived = 0;
                }
                else if (replayAnswer == "2")
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("You must enter a valid input");
                } 

            } while (string.IsNullOrWhiteSpace(replayAnswer) || (replayAnswer != "1" && replayAnswer != "2"));

        } while (playAgain);
        
        Console.WriteLine("\nThank you for playing!");
    }
}