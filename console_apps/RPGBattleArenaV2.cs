/*
Goal:
Build a console game where a player fights a group of enemies ony by one
Each enemy has random health and attack values.
The player can attack, heal or flee

Rules & requirements
    - Player setup
        - Starts with 100 HP
        - Each turn, player chooses:
            - 1. Attack (deal random 10-25 damage)
            - 2. Heal (restore random 5-15 HP, capped at 100)
            - 3. Flee (end the game early)
    - Enemies setup
        - User a for loop to spawn 3 enemies (Enemy 1, Enemy 2, Enemy 3)
        - Each enemy starts with random HP between 40-70
        - Enemy attacks deal random 5-20 damage
    - Battle logic
        - Use a do-while loop to repeat turns until either:
            - The enemy dies
            - The player dies
            - The player flees
    - After each battle
        - Print result ("Enemy defeated" or "You died")
        - If the player survided and hasn't fled, move to the next enemy
    - Game end
        - After all enemies are defeated or the player dies/flees
            - Print a summary like
                - Game over! You defeated X enemies.

Output:
---------------------
RPG BATTLE ARENA V2.0
---------------------
Enemy 1 appears! HP: 63

Your HP: 100
Choose action: (1) Attack (2) Heal (3) Flee
> 1
You deal 18 damage!
Enemy HP: 45

Enemy attacks! You take 9 damage.
Your HP: 91
...

Enemy defeated!
---------------------
Enemy 2 appears! HP: 54
...
*/
public class RPGBattleArenaV2
{
    public static void RunApp()
    {

        Console.WriteLine("--------------------");
        Console.WriteLine("RPG BATTLE ARENA 2.0");
        Console.WriteLine("--------------------");

        // Player
        int playerHP = 100;
        int playerAttackPoints;
        int playerHealPoints;
        bool validPlayerInput;
        int parsedPlayerInput;

        // Monsters
        int currentMonster = 1;
        int totalMonsters = 3;
        int monsterHP = 40;
        int monsterAttackPoints;

        // Battle
        bool playerDies = false;
        bool currentMonsterDies;
        bool playerFlees = false;
        bool allMonstersdied = false;
        Random randomPoints = new();

        for (int i = 1; i <= totalMonsters; i++)
        {
            currentMonsterDies = false;
            currentMonster = i;
            monsterHP = randomPoints.Next(40, 71);
            Console.WriteLine($"Enemy {currentMonster} appears! HP {monsterHP}");

            // BATTLE
            do
            {
                do
                {
                    // PLAYER TURN
                    Console.WriteLine("--------------");
                    Console.WriteLine("Choose action!");
                    Console.WriteLine("--------------");
                    Console.WriteLine("1 - Attack\n2 - Heal\n3 - Flee");
                    Console.WriteLine("--------------");
                    string? playerInput = Console.ReadLine();
                    validPlayerInput = int.TryParse(playerInput, out parsedPlayerInput);

                    Console.WriteLine("\n---");
                    if (parsedPlayerInput == 1)
                    {
                        // Attack
                        Console.WriteLine($"You attack!");
                        playerAttackPoints = randomPoints.Next(10, 26);
                        Console.WriteLine($"You deal {playerAttackPoints} damage!");

                        monsterHP -= playerAttackPoints;
                        if (monsterHP < 0) monsterHP = 0;
                        Console.WriteLine($"Enemy HP: {monsterHP}");
                        if (monsterHP == 0)
                        {
                            currentMonsterDies = true;
                            Console.WriteLine($"Monster {currentMonster} felled!");
                        }
                    }
                    else if (parsedPlayerInput == 2)
                    {
                        // Heal
                        if (playerHP == 100)
                        {
                            Console.WriteLine("Already at max HP");
                        }
                        else
                        {
                            playerHealPoints = randomPoints.Next(5, 16);
                            Console.WriteLine($"You healed {playerHealPoints} HP!");
                            playerHP += playerHealPoints;
                            if (playerHP > 100) playerHP = 100;
                            Console.WriteLine($"Your HP: {playerHP}");
                        }
                    }
                    else if (parsedPlayerInput == 3)
                    {
                        // Flee
                        playerFlees = true;
                        Console.WriteLine("You fled like a lil bitch");
                    }
                    else
                    {
                        Console.WriteLine("You must enter a valid command!");
                    }
                    Console.WriteLine("---\n");

                } while (!validPlayerInput || parsedPlayerInput > 3 || parsedPlayerInput < 0);

                // MONSTER TURN
                if (!currentMonsterDies && !playerFlees)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"Monster {currentMonster} attacks!");
                    monsterAttackPoints = randomPoints.Next(5, 21);
                    Console.WriteLine($"You take {monsterAttackPoints} damage!");
                    playerHP -= monsterAttackPoints;
                    if (playerHP < 0) playerHP = 0;
                    Console.WriteLine($"Your HP: {playerHP}");
                    playerDies = playerHP <= 0;
                    Console.WriteLine("---\n");
                }

            } while (!playerDies && !currentMonsterDies && !playerFlees);

            if (currentMonster == 3 && currentMonsterDies)
                allMonstersdied = true;

            if (playerDies || allMonstersdied || playerFlees) break;
        }

        if (playerDies) Console.WriteLine("You died");
        else if (allMonstersdied) Console.WriteLine("You survived the slaughter");
        else if (playerFlees) Console.WriteLine("Coward!");

        Console.WriteLine("GAME OVER");
    }
}