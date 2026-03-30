/*
Premise:
You are a lone warrior who enters a cursed gauntlet. Three demons stand between you and the exit.
Fight through all three or die trying.

Setup:
- Player starts with 30 HP
- Each demon has random HP between 15-25
- Demons are named: Ashveil, Dreadmaw, The hollow

Each round:
- Enter to attack
- Player deals random 3-8 damage
- Demon deals random 2-6 damage
- 25% chance either attack is a critical hit -- Double the damage
- Print what happened, print both HPs after each round

Between demons:
- Print a short flavour message (you decide what)
- Player heals 5HP (max 30) before the next demon

Game ends when:
- Player defeats all three demons --> "The gauntlet is yours. For now."
- Player dies --> "The darkness takes you."

Bad input:
- Anything other than Enter --> print a short sneer and don't advance the round

Expected output:
----------------------------------------
THE CURSED GAUNTLET v1.0
----------------------------------------
Ashveil emerges from the shadows. HP: 21
----------------------------------------
Press Enter to fight. Q to flee like a dog.

You strike Ashveil for 6 damage.
Ashveil claws back for 3 damage.

Your HP: 27 | Ashveil HP: 15
...

*/

public class ShortRefEx004TheCursedGauntlet
{
    private float playerHealth = 30;
    private Random randomGenerator= new();
    private float ashveilHealth, dreadmawHealth, theHollowHealth;
    private string? currentDemonName;
    private float currentDemonHealth;
    private bool enemyGreeted = false;
    private bool quitGame = false;

    public void RunApp()
    {
        ashveilHealth = randomGenerator.Next(15, 26);
        dreadmawHealth = randomGenerator.Next(15, 26);
        theHollowHealth = randomGenerator.Next(15, 26);

        int enemySelector = randomGenerator.Next(1, 4);

        ConsoleKeyInfo key;

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("THE CURSED GAUNTLET v1.0");
        Console.WriteLine("----------------------------------------");

        switch (enemySelector)
        {
            case 1:
                currentDemonName = "Ashveil";
                currentDemonHealth = ashveilHealth;
                break;
            case 2:
                currentDemonName = "Dreadmaw";
                currentDemonHealth = dreadmawHealth;
                break;
            case 3:
                currentDemonName = "The Hollow";
                currentDemonHealth = theHollowHealth;
                break;
            default:
                currentDemonName = "Ashveil";
                currentDemonHealth = ashveilHealth;
                break;
        }

        do
        {
            if (!enemyGreeted)
            {
                Console.WriteLine($"{currentDemonName} emerges from the shadows. HP: {currentDemonHealth}");
                enemyGreeted = true;   
            }
            
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Press Enter to fight. Q to flee like a dog.");
            Console.WriteLine("----");
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Attack();
                    break;
                case ConsoleKey.Q:
                    QuitGame();
                    break;
                default:
                    UnrecognizedInput();
                    break;
            }

        } while (!quitGame && playerHealth > 0);
    }

    private void Attack()
    {
        /*
        Each round:
            - Enter to attack
            - Player deals random 3-8 damage
            - Demon deals random 2-6 damage
            - 25% chance either attack is a critical hit -- Double the damage
            - Print what happened, print both HPs after each round
        */

        // 1. Player turn-----------
        float playerDmg = randomGenerator.Next(3, 9);
        float playerCritDmgChance = randomGenerator.Next(1, 5);
        bool isPlayerCriticalHit = false;
        
        if (playerCritDmgChance == 4)
        {
            playerDmg *= 2;
            isPlayerCriticalHit = true;
        }

        if (isPlayerCriticalHit)
            Console.WriteLine($"Player critical hit! You strike {currentDemonName} for {playerDmg} damage");
        else
            Console.WriteLine($"You strike {currentDemonName} for {playerDmg} damage");

        isPlayerCriticalHit = false;

        currentDemonHealth -= playerDmg;

        if (currentDemonHealth < 0) currentDemonHealth = 0;
        //-------------------------

        // 2. Demon turn-----------
        float demonDmg = randomGenerator.Next(2, 7);
        float demonCritDmgChance = randomGenerator.Next(1, 5);
        bool isDemonCriticalHit = false;

        if (demonCritDmgChance == 4)
        {
            demonDmg *= 2;
            isDemonCriticalHit = true;
        }

        if (isDemonCriticalHit)
            Console.WriteLine($"Demon critical hit! {currentDemonName} strikes you for {demonDmg} damage");
        else
            Console.WriteLine($"{currentDemonName} strikes you for {demonDmg} damage");

        isDemonCriticalHit = false;

        playerHealth -= demonDmg;
        
        if (playerHealth < 0) playerHealth = 0;
        //--------------------------

        // 3. Round summary---------
        Console.WriteLine($"Your HP: {playerHealth} | {currentDemonName} HP: {currentDemonHealth}");

        /*
            LEFT HERE: How can I discard the enemy once I defeat it, and move to the next one?

            Break it down:
            1. 

        */
        //--------------------------
    }

    private void QuitGame()
    {
        Console.WriteLine("Closing game.\nGood bye...");
        quitGame = true;
    }

    private void UnrecognizedInput()
    {
        Console.WriteLine("Unrecognized input");
    }
}