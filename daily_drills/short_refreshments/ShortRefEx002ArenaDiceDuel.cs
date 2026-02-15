/*
Premise:
- You enter a small arena duel.
- Each round you and an enemy roll a dice.
- Whoever rolls higher deals 2 damage to the other

Starting stats:
- Player HP: 10
- Enemy HP: 10

Rules:
1. Use a while or do-while loop to run the battle
2. Each run:
    - Print: "Press Enter to roll the dice"
    - Wait for input
    - Generate:
        - Player roll -> random 1-6
        - Enemy roll -> random 1-6
3. Compare rolls:
    If player roll > enemy roll -> enemy loses 2HP
    If enemy roll > player roll -> player loses 2HP
    If equal -> print "Clash! No damage"
4. After each round print both HP values
5. The game ends when:
    - Player HP <= 0
    - Enemy HP <= 0

End message:
    If player wins -> "Victory in the arena!"
    If player loses -> "You were defeated"

Constraints:
    - Use only:
        - loops
        - conditionals
        - bools
        - Random
        - Console input/output
*/
public class ShortRefEx002ArenaDiceDuel
{
    public static void RunApp()
    {
        int playerHP = 10;
        int enemyHP = 10;

        int globalDamage = 2;

        Random dice = new();

        bool playerDied = false;
        bool enemyDied = false;

        Console.WriteLine("------------------------------");
        Console.WriteLine("-----ARENA DICE DUEL v1.0-----");
        Console.WriteLine("------------------------------");
        Console.WriteLine("\n");

        do
        {
            Console.WriteLine("Press any key to roll the dice");
            Console.ReadLine();

            int playerHand = dice.Next(1, 7);
            int enemyHand = dice.Next(1,7);

            if (enemyHand > playerHand)
            {
                playerHP -= globalDamage;
                Console.WriteLine("You Took 2HP damage!");
            }
            else if (playerHand > enemyHand)
            {
                enemyHP -= globalDamage;
                Console.WriteLine("You dealt 2HP damage!");
            }
            else
            {
                Console.WriteLine("Clash! No damage.");
            }
            Console.WriteLine("--------------------");
            Console.WriteLine($"Your health: {playerHP}");
            Console.WriteLine($"Enemy health: {enemyHP}");

            // Check player and enemy health
            if (playerHP <= 0)
            {
                Console.WriteLine("\n");
                Console.WriteLine("You died!💀");
                playerDied = true;
            }
            else if (enemyHP <= 0)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The enemy died!");
                enemyDied = true;
            }
            Console.WriteLine("--------------------");
        }
        while (!playerDied && !enemyDied);
    }
}