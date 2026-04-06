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
    public void RunApp()
    {
        /*
            Premise:
                - You arrive at a blacksmith's shop before facing a dungeon boss. Your gold is limited your time is short. Choose your weapon wisely - It's the only edge you'll have
            Setup:
                - Player starts with 50 gold and 25 HP
                - Three weapons available for purchase, each with a different price and attack range

        */

        int playerHealth = 25;
        int playerGold = 50;

        string[] shopWeapons = {"Master mace", "Great sword", "Double-edged axe"};

        Random randomGenerator = new();
        int bossHealth = randomGenerator.Next(20, 36);

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Welcome to the Blacksmith Forge.");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < shopWeapons.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {shopWeapons[i]}");
        }
        string? choosenWeapon = Console.ReadLine();
        Console.WriteLine($"You choose {choosenWeapon}");
    }
}