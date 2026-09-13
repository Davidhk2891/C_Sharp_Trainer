/*
// 1. Define and write global variables and Enums
// 2. Define main functions (just name and params)
// 2. Write 2 most known functions to unlock freeze (in this case, GetWinner() and GetRandomNumber()
// 3. Define and write core game function which will be core game loop
    - Grab player's name
    - Prompt player to pick random element
    - Assign starting element to player
    - Prompt a player that a random obstacle of a random element approaches. Ask to engage or flee
        - If engage, call GetWinner()
            - If player wins, grant reward, go back to top of game play loop
            - If player loses, game over
            - If tie, player loses element, go back to top of game play loop
        - If flee, call Flee()
            - Player loses 20 hp
            - Player goes back to top of game play loop
// 4. Add UI
    - Add HUD using PadRight()
*/
using System.Diagnostics;

public class DailyEx014FlappyElementalQuickduelV1
{
    // GAME BALANCER
    private static int INITIAL_PLAYER_LIFE = 100;
    // RNG
    private Random globalRNG = new Random();

    // ANIMATION
    private static int ANIM_SPIN_SPEED = 100;
    private static byte ANIM_SPIN_ROUNDS = 3;

    // UI
    private string? UIprompt;

    // PLAYER
    private string? playerInput = "";
    private string playerSelection = "";
    private string playerName = "";
    private int playerLife = INITIAL_PLAYER_LIFE;
    private Element randomPlayerElement = Element.None;

    // COMPUTER
    private Element randomComputerElement = Element.None;
    private Enemy randomComputerEnemy = Enemy.Pipe;

    // MATCH
    private Boolean isGameOver = false;

    private enum Element
    {
        Fire,
        Water,
        Ice,
        None
    }

    private enum Enemy
    {
        Pipe,
        Bat,
        Spinner,
        Bitter
    }

    private enum DuelOutcome
    {
        Player,
        Computer,
        Tie
    }

    public void StartGame()
    {
        ClearScreen();
        RunGameIntro();
        RunGameCoreLoop();
    }

    private void RunGameIntro()
    {
        RunSpinAnimation();
        string line = "--------------------------------------";
        string title = "  FLAPPY ELEMENTAL - QUICK DUEL V1.0";
        string intro = $"{line}";
        intro += $"\n{title}";
        intro += $"\n{line}";
        Write(intro);
    }

    private void RunGameCoreLoop()
    {
        RunSpinAnimation();
        // 1. Grab player's name
        do
        {
            UIprompt = "Enter your name:";
            Write(UIprompt);
            playerInput = Console.ReadLine();

            if (playerInput != null)
            {
                playerName = playerInput;
            }

        } while (playerInput == null);
        playerInput = null;
        Write($"NAME: {playerName}");

        do
        {            
            // 2. Prompt player to select random element or none
            do
            {
                UIprompt = "Select random element? (y/n)";
                Console.WriteLine(UIprompt);
                playerInput = Console.ReadLine();

                if (playerInput != "" && 
                    (playerInput == "y".ToLower() || playerInput == "n".ToLower()))
                {
                    playerSelection = playerInput;
                }
                else
                {
                    Write("You must select a valid option");
                }            
            } while (playerInput == "" || (playerInput != "y" && playerInput != "n"));

            if (playerSelection == "y")
            {
                randomPlayerElement = GetRandomElement();
                UIprompt = $"You've gotten the {randomPlayerElement} element.";
            }
            else
            {
                UIprompt =$"You've chosen no element.";
            }
            Write(UIprompt);

            // 3. Notify player that random obstacle with random element appeared
            randomComputerEnemy = GetRandomEnemy();
            randomComputerElement = GetRandomElement();

            do
            {
                UIprompt = $"A wild {randomComputerEnemy} of type {randomComputerElement} has appeared.";
                UIprompt += "\nDo you want to engage? (y/n)";
                Console.WriteLine(UIprompt);
                playerInput = Console.ReadLine();

                if (playerInput != null &&
                    (playerInput == "y".ToLower() || playerInput == "n".ToLower()))
                {
                    playerSelection = playerInput;
                }
                else
                {
                    Write("You must select a valid option");
                }
            } while (playerInput == null || (playerInput != "y" && playerInput != "n"));

            if (playerSelection == "y")
            {
                // Engage
                RunSpinAnimation();
                DuelOutcome matchResult = GetWinner(randomPlayerElement, randomComputerElement);
                if (matchResult == DuelOutcome.Player)
                {
                    UIprompt = $"{DuelOutcome.Player} WINS!";    
                    UIprompt += "\n\nENEMY FELLED";
                }
                else if (matchResult == DuelOutcome.Computer)
                {
                    UIprompt = $"{DuelOutcome.Computer} WINS!";
                    UIprompt += "\n\nYOU DIED";
                    isGameOver = true;
                }
                else
                {
                    randomPlayerElement = Element.None;
                    UIprompt = $"{DuelOutcome.Tie}.";
                    UIprompt += "\n\nYOU LOST YOUR ELEMENT";
                }
                Write(UIprompt);
            }
            else
            {
                // Flee
                UIprompt = "You've chosen to flee the encounter.";
                UIprompt = "You've lost 20 HP.";
                playerLife -= 20;                
                Write(UIprompt);
            }

            if (isGameOver == false)
            {
                if (playerLife <= 0)
                {
                    playerLife = 0;
                    isGameOver = true;   
                }
            }
            
        } while (!isGameOver);
    }

    private DuelOutcome GetWinner(Element playerElement, Element compElement)
    {
        DuelOutcome duelOutcome = DuelOutcome.Tie;
        // Fire -> Ice -> Water
        if (playerElement == Element.Fire)
        {
            if (compElement == Element.Ice)            
                duelOutcome = DuelOutcome.Player;                    
            else if (compElement == Element.Water)
                duelOutcome = DuelOutcome.Computer;            
        }
        else if (playerElement == Element.Water)
        {
            if (compElement == Element.Fire)            
                duelOutcome = DuelOutcome.Player;                    
            else if (compElement == Element.Ice)
                duelOutcome = DuelOutcome.Computer;
        }
        else if (playerElement == Element.Ice)
        {
            if (compElement == Element.Water)            
                duelOutcome = DuelOutcome.Player;                    
            else if (compElement == Element.Fire)
                duelOutcome = DuelOutcome.Computer;
        }
        else
        {
            // Player element is None
            duelOutcome = DuelOutcome.Computer;
        }
        return duelOutcome;
    }

    private Element GetRandomElement()
    {
        Element element = Element.None;
        // RNG
        int randomElementAssignment = globalRNG.Next(1, 4);
        switch (randomElementAssignment)
        {
            case 1:
                element = Element.Fire;
                break;
            case 2:
                element = Element.Water;
                break;
            case 3:
                element = Element.Ice;
                break;            
        }
        return element;              
    }

    private Enemy GetRandomEnemy()
    {
        Enemy enemy = Enemy.Pipe;
        // RNG
        int randomEnemyAssignment = globalRNG.Next(1, 4);
        switch (randomEnemyAssignment)
        {
            case 1:
                enemy = Enemy.Pipe;
                break;
            case 2:
                enemy = Enemy.Bat;
                break;
            case 3:
                enemy = Enemy.Spinner;
                break;
            case 4:
                enemy = Enemy.Bitter;
                break;
        }
        return enemy;
    }

    // Utilities
    private void RunSpinAnimation(string message = "Loading...")
    {
        string[] spinChars = ["\\","|","/","--"];
        for (int i = 0; i < ANIM_SPIN_ROUNDS; i++)
        {
            for (int j = 0; j < spinChars.Length; j++)
            {
                Console.Write($"\r{new String(' ', Console.BufferWidth - 1)}");
                Console.Write($"\r{message}{spinChars[j % spinChars.Length]}");
                Thread.Sleep(ANIM_SPIN_SPEED);
            }   
        }
        Console.Clear();
    }

    private void Write(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
    }

    private void ClearScreen()
    {
        Console.Clear();
    }
}