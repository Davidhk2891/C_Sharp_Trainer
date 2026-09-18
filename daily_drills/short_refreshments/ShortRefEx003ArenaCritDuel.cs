/*
Premise:
Another arena fight. This time attacks can critically strike

Starting stats:
Player: 15 HP
Mob: 15 HP

Rules:
1.	Use a while or do-while loop.
2.	Each round:
    •	Print: "Press Enter to attack"
    •	Wait for input.
    •	Both player and enemy attack once.
3.	Attack logic:
    •	Base damage: random 2–5
    •	20% chance of critical hit
    •	Critical hit = double damage
4.	Print for each attack:
    •	Damage dealt
    •	Whether it was critical
5.	After each round:
    •	Print both HP values
6.	End when:
    •	Player HP ≤ 0
    •	Enemy HP ≤ 0

End Messages:
If player wins → "You dominate the arena!"
If player loses → "You fall in battle..."

Constraints:
Only use:
	•	loops
	•	conditionals
	•	bools
	•	Random
	•	Console input/output
No arrays.
No methods.
No advanced tricks.
*/
public class ShortRefEx003ArenaCritDuel
{
    private float playerHP = 15;
    private float mobHP = 15;
    private bool isPlayerDead = false;
    private bool isMobDead = false;
    private bool quitGame = false;
    readonly Random random = new();
    public void RunApp()
    {
        ConsoleKeyInfo key;

        Console.WriteLine("--------------------");
        Console.WriteLine("ARENA CRIT DUEL v1.0");
        Console.WriteLine("--------------------");

        do
        {

            Console.WriteLine("\nACTIONS:");
            Console.WriteLine("Enter - Attack\nQ - Exit game\n");

            key = Console.ReadKey(true);

            Console.WriteLine("---------------");
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Attack();
                    CheckContestantsHealth();
                    break;
                case ConsoleKey.Q:
                    QuitGame();
                    break;
                default:
                    UnrecognizedInput();
                    break;
            }
            Console.WriteLine("---------------");

        } while (!isPlayerDead && !isMobDead && !quitGame);
    }

    private void Attack()
    {   
        float playerBaseDamage = random.Next(2, 6);
        float mobBaseDamage = random.Next(2, 6);

        float playerCritRate = 2;
        float mobCritRate = 1.2f;

        float playerDmg = playerBaseDamage;
        float mobDmg = mobBaseDamage;
    
        bool isPlayerCritAttack = CritAttackResolver();
        bool isMobCritAttack = CritAttackResolver();

        if (isPlayerCritAttack)
        {
            playerDmg *= playerCritRate;
            Console.WriteLine($"You attack the mob and deal {playerDmg} CRITICAL damage");
        }
        else
        {
            Console.WriteLine($"You attack the mob and deal {playerDmg} damage");
        }
        mobHP -= playerDmg;

        if (isMobCritAttack)
        {
            mobDmg *= mobCritRate;

            Console.WriteLine($"The mob attacks you and deals {mobDmg} CRITICAL damage");
        }
        else
        {
            Console.WriteLine($"The mob attacks you and deals {mobDmg} damage");
        }
        playerHP -= mobDmg;
    }

    private void CheckContestantsHealth()
    {
        if (playerHP < 0) playerHP = 0;
        if (mobHP < 0) mobHP = 0;

        Console.WriteLine($"Player HP: {playerHP}");
        Console.WriteLine($"Mob HP: {mobHP}");

        if (playerHP <= 0)
        {
            isPlayerDead = true;
            Console.WriteLine("You died");
        }
        else if (mobHP <= 0)
        {
            isMobDead = true;
            Console.WriteLine("Mob befelled");
        }
    }

    private bool CritAttackResolver()
    {
        return random.Next(1, 11) >= 8;
    }

    private void QuitGame()
    {
        Console.WriteLine("Quiting game...");
        quitGame = true;
    }

    private static void UnrecognizedInput()
    {
        Console.WriteLine("Input not recognized");
    }
}