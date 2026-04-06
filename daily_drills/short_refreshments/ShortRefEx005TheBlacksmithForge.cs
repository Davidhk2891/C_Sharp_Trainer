/*
-------------------------
THE BLACKSMITH FORGE v1.0
-------------------------
Premise:
    - You arrive at a blacksmith's shop before facing a dungeon boss. Your gold is limited, your time is short. Choose your weapon wisely — it's the only edge you'll have.
Setup:

    - Player starts with 50 gold and 25 HP
    - Three weapons available for purchase, each with a different price and attack range
    - Boss has random HP between 20-35
    - After purchase, the fight plays out round by round (press Enter to advance each round)
    - No crits this time

Rules:

    - Display a numbered weapon menu (1, 2, 3) with name, price, and attack range
    - Player selects a weapon by typing a number and pressing Enter
    - Invalid input (letters, out of range, not enough gold) → sneer and re-prompt
    - Each round: player attacks, then boss attacks (if still alive)
    - Player attack = random roll within the chosen weapon's range
    - Boss deals random 3-7 damage per round
    - Print round results each round
    - Game ends when either HP hits zero
    - Win: "The beast falls. The forge-master nods."
    - Lose: "The darkness takes you. Again."
*/

public class ShortRefEx005TheBlacksmithForge
{
    private Random randomGenerator = new();
    private int playerHealth = 25;
    private int playerGold = 50;
    private string playerWeapon;
    private string playerWeaponDmgRange;
    private string? playerChoice;
    private string[] weaponNames = {"Master mace", "Great sword", "Solider axe"};
    private int[] weaponPrices = {15, 20, 25};
    private string[] weaponDmgRanges = new string[3];
    private bool isPlayerDead = false;
    private bool isBossDead = false;

    private bool exitGame = false;

    public void RunApp()
    {
        // Intro
        Intro();

        // Choose weapon
        ChooseWeapon();

        // Engage boss
        EngageBoss();
    }

    private void Intro()
    {
        Console.WriteLine("\n");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Welcome to the Blacksmith Forge.");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"-----------------------Gold: {playerGold}-");
    }

    private void ChooseWeapon()
    {
        weaponDmgRanges[0] = "5 - 10";
        weaponDmgRanges[1] = "3 - 12";
        weaponDmgRanges[2] = "4 - 14";

        for (int i = 0; i < weaponNames.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {weaponNames[i]} | Dmg: {weaponDmgRanges[i]} | Cost: {weaponPrices[i]}");
        }
        Console.WriteLine("Q - Quit game");
        playerChoice = Console.ReadLine();
        
        do
        {
            switch (playerChoice)
        {
            case "1":
                playerWeapon = weaponNames[0];
                playerWeaponDmgRange = weaponDmgRanges[0];
                playerGold -= weaponPrices[0];
                break;
            case "2":
                playerWeapon = weaponNames[1];
                playerWeaponDmgRange = weaponDmgRanges[1];
                playerGold -= weaponPrices[1];
                break;
            case "3":
                playerWeapon = weaponNames[2];
                playerWeaponDmgRange = weaponDmgRanges[2];
                playerGold -= weaponPrices[2];
                break;
            case "q":
                ExitGame();
                break;
            default:
                InvalidInputMessage();
                break;
        }    
        } while (playerChoice != "1" && playerChoice != "2" && playerChoice != "3" && !exitGame);
        
        if (playerChoice == "1" || playerChoice == "2" || playerChoice == "3")
        {
            Console.WriteLine($"-----------------------Gold: {playerGold}-");
            Console.WriteLine($"You bought {playerWeapon}");
            Console.WriteLine("Good luck.");
            Console.WriteLine("--------------------------------");
        }
    }

    private void EngageBoss()
    {
        int bossHealth = randomGenerator.Next(20, 36);    
        int bossAttackDmgRange;   
        string bossName = "The Ice Queen";
        Console.WriteLine($"You engage the Boss. {bossName}.");

        do
        {
            // Player attacks boss
            var playerAttackDmgRange = playerWeaponDmgRange switch
            {
                "5 - 10" => randomGenerator.Next(5, 11),
                "3 - 12" => randomGenerator.Next(3, 13),
                "4 - 14" => randomGenerator.Next(4, 15),
                _ => 0,
            };

            bossHealth -= playerAttackDmgRange;

            Console.WriteLine($"You attack {bossName} and deal {playerAttackDmgRange} damage");   

            /*
                - Player attack = random roll within the chosen weapon's range
                - Boss deals random 3-7 damage per round
                - Print round results each round
                - Game ends when either HP hits zero
                - Win: "The beast falls. The forge-master nods."
                - Lose: "The darkness takes you. Again."

                PROVIDE LINK TO C# NOTES TO CLAUDE TO SEE HOW THE NOTES CAN BE IMPROVED
            */

            if (bossHealth <= 0)
            {
                if (bossHealth < 0) bossHealth = 0;
                isBossDead = true;
            }

            // Boss attacks player
            if (!isBossDead)
            {
                Thread.Sleep(1000);
                bossAttackDmgRange = randomGenerator.Next(3, 8);
                playerHealth -= bossAttackDmgRange;
                Console.WriteLine($"{bossName} attacks you and deals {bossAttackDmgRange} damage");
            }

            // Turn summary LEFT HERE !!

            Console.WriteLine($"Player health: {playerHealth}");

        } while (!isPlayerDead && !isBossDead);
    }

    private void ExitGame()
    {
        Console.WriteLine("Good bye.");
        exitGame = true;
    }

    private void InvalidInputMessage()
    {
        Console.WriteLine("Invalid input. Please try again");
    }
}