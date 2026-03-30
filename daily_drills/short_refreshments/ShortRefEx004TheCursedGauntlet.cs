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
    private int playerHealth = 30;
    private Random randomGenerator= new();
    private float ashveilHealth, dreadmawHealth, theHollowHealth;

    private bool isAshveilDead = false;
    private bool isDreadmawDead = false;
    private bool isThehollowDead = false;

    public void RunApp()
    {
        ashveilHealth = randomGenerator.Next(15, 26);
        dreadmawHealth = randomGenerator.Next(15, 26);
        theHollowHealth = randomGenerator.Next(15, 26);

        int enemySelector = randomGenerator.Next(1, 4);
        string currentDemonName;
        float currentDemonHealth;

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
            Console.WriteLine($"{currentDemonName} emerges from the shadows. HP {currentDemonHealth}");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Press Enter to fight. Q to flee like a dog.");
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Attack(currentDemonName, currentDemonHealth);
                    break;
                case ConsoleKey.Q:
                    QuitGame();
                    break;
                default:
                    UnrecognizedInput();
                    break;
            }

        } while (playerHealth > 0);
    }

    private void Attack(string currentDemonName, float currentDemonHealth)
    {
        /*
        Each round:
            - Enter to attack
            - Player deals random 3-8 damage
            - Demon deals random 2-6 damage
            - 25% chance either attack is a critical hit -- Double the damage
            - Print what happened, print both HPs after each round
        */

        float playerAttackDmg = randomGenerator.Next(3, 9);
        Console.WriteLine($"You strike {currentDemonName} for {playerAttackDmg}");
        currentDemonHealth -= playerAttackDmg;

        if (currentDemonHealth <= 0)
        {
            if (currentDemonName == "Ashveil") isAshveilDead = true;
            else if (currentDemonName == "Dreadmaw") isDreadmawDead = true;
            else if (currentDemonName == "The Hollow") isThehollowDead = true;

            Console.WriteLine($"You've slain {currentDemonName}.");
        }
        
        float DemonAttackDmg = randomGenerator.Next(2, 7);
        Console.WriteLine($"{currentDemonName}");
    }

    private void QuitGame()
    {
        
    }

    private void UnrecognizedInput()
    {
        Console.WriteLine("Unrecognized input");
    }
}