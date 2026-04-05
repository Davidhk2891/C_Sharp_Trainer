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
    private string? currentDemonName;
    private float currentDemonHealth;
    private bool enemyGreeted = false;
    private bool quitGame = false;
    private bool playerDied = false;
    private bool demonDied = false;
    private bool allDemonsDied = false;
    private string[] mobsNames = {"Ashveil", "Dreadmaw", "The Hollow"};
    private float[] mobsLifes = new float[3];
    private ConsoleKeyInfo key;

    public void RunApp()
    {

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("THE CURSED GAUNTLET v1.0");
        Console.WriteLine("----------------------------------------");

        for (int i = 0; i < mobsNames.Length; i++)
        {

            mobsLifes[i] = randomGenerator.Next(15, 26);

            currentDemonName = mobsNames[i];
            currentDemonHealth = mobsLifes[i];

            enemyGreeted = false;
            demonDied = false;
             
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

            } while (!quitGame && !playerDied);

            if (quitGame || playerDied) break;
        }

        if (!playerDied)
        {
            allDemonsDied = true;
        }
    }

    private void Attack()
    {
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

        if (currentDemonHealth <= 0)
        {
            currentDemonHealth = 0; 
            demonDied = true;   
        }
        //-------------------------

        // 2. Demon turn-----------
        if (currentDemonHealth != 0)
        {
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
            
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                playerDied = true;      
            }
        }
        //--------------------------

        // 3. Round summary---------
        if (playerDied)
        {
            Console.WriteLine($"Your HP: {playerHealth} | {currentDemonName} HP: {currentDemonHealth}");
            Console.WriteLine("YOU DIED.");
        }
        else if (demonDied)
        {
            Console.WriteLine($"ENEMY FELLED");
            Console.WriteLine("You recovered 10 HP");
            playerHealth += 10;
            Console.WriteLine($"Your HP: {playerHealth} | {currentDemonName} HP: {currentDemonHealth}");
        }
        else
        {
            Console.WriteLine($"Your HP: {playerHealth} | {currentDemonName} HP: {currentDemonHealth}");
        }
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