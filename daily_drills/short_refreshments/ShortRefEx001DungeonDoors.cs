/*
Short refresher: Dungeon Doors
Premise:
    You are exploring a dungeon corridor.
    Each turn, you choose to open a mysterious door.
    Behind each door there is either:
	    •	💰 Treasure (+5 gold)
	    •	💀 Trap (-3 HP)
    You start with:
	    •	10 HP
	    •	0 Gold
Rules:
    1.	Use a while or do-while loop to continue the game.
	2.	Each turn:
	    •	Ask the player: “Open the next door? (y/n)”
	3.	If they type y:
	    •	Randomly decide:
	        •	50% chance → treasure (+5 gold)
	        •	50% chance → trap (-3 HP)
	        •	Print the result.
	4.	If they type n:
	    •	The game ends voluntarily.
	5.	The game also ends automatically if HP ≤ 0.
	6.	After each turn, print:
	    •	Current HP
	    •	Current Gold
End conditions:
    At the end print:
	    •	If HP ≤ 0 → "You died in the dungeon!"
	    •	Otherwise → "You escaped with X gold!"
Constraints:
	•	Only use what you’ve learned:
	    •	loops
	    •	bools
	    •	conditionals
        •	Random
        •	basic input handling
        •	No advanced stuff.
        •	No extra features.
*/

public class ShortRefEx001DungeonDoors
{
    public static void RunApp()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("-----DUNGEON DOORS. v1.0-----");
        Console.WriteLine("-----------------------------");
        // Player specs
        int playerLife = 10;
        int playerGold = 0;
        Random rand = new();
        bool playerDied = false;
        string? doorAction = "";

        while (!playerDied && doorAction != "n")
        {
            Console.WriteLine("Open the next door? y/n");
            doorAction = Console.ReadLine();

            if (doorAction == "y")
            {
                Console.WriteLine("You choose to open the next door!");
                int roomOutcome = rand.Next(0, 2);
                if (roomOutcome == 0)
                {
                    Console.WriteLine("You collected. +5 gold 💰");
                    playerGold += 5;
                } 
                else
                {
                    Console.WriteLine("You lose -3 HP 💀");
                    playerLife -= 3;
                }

                // Check player HP
                if (playerLife <= 0)
                {
                    playerDied = true;
                    if (playerLife < 0) playerLife = 0;
                    Console.WriteLine($"Your HP: {playerLife}\nYou died 💀💀💀");
                }
                else
                {
                    Console.WriteLine($"Your HP: {playerLife}");   
                }
                Console.WriteLine($"Gold collected: {playerGold}");
            }
            else
            {
                Console.WriteLine("You choose not to open the next door.");
                Console.WriteLine($"You walked away alive and with {playerGold} gold");
                Console.WriteLine("Good bye");
            }
        }
    }
}