/*
Premise:
    - You are a flyer entering the gauntlet. Type your name, pick a starting element,
        and survive as many rounds as possible against incoming elemental obstacles.
Setup:
    - Player types the name at the start
    - Player gets a random element
    - Each round: Random obstacle with random element appears
    - Player grabs a chip or skips then engages or dodges
    - 20 HP. Game ends at 0
Rules:
    - Use Element and FightOutcome enums. Build GetWinner() from memory
    - Validate all input with int.TryParse()
    - HUD each round: playerName, playerElement, playerHP -> Formatted with PadRight()
    - Each round result stored as a string, final summary built String.Join("\n", results[])
    - Use modulus every 3rd round to trigger "⚠️ Element Shift!" (Obstacle element changes twice
        rapidly before settling)
    - Use ternary at least once for result formatting
    - Player name in all caps using ToUpper()
*/
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

public class DailyEx013FlappyElementalSurvivalRunV2
{
    private Random rng = new();
    private String? playerName = "";
    Element playerElement;
    int playerHealth = 20;
    int playerCoins = 0;
    int currentRound = 1;
    public void RunApp()
    {
        UIGameIntro();
        BeginCoreLoop();
    }

    private enum Element
    {
        Water,
        Fire,
        Ice,
        None
    }

    private enum Obstacle
    {
        Column,
        Wall,
        Bat,
        Skull,
        Trap        
    }

    private enum FightOutcome
    {
        Player,
        Obstacle,
        Draw
    }

    private void BeginCoreLoop()
    {
        string stackedGameMessage = "";

        playerElement = GetElementNone();

        Element obstacleElement;
        Obstacle currentObstacle;

        bool isGameOver = false;

        EnterName();

        do
        {
            string? playerInput;
            stackedGameMessage = "Get new element?";
            stackedGameMessage += "\n\n1 - Yes\n2 - No";
            UIGameLoop(stackedGameMessage);
            do
            {
                playerInput = Console.ReadLine();
                if (playerInput != "1" && playerInput != "2")
                {
                    stackedGameMessage += "\n\nPlease enter a valid input";
                    UIGameLoop(stackedGameMessage);
                }
            } while (playerInput != "1" && playerInput != "2");

            if (playerInput == "1")
                playerElement = GetRandomElement();
        
            currentObstacle = GetRandomObstacle();
            obstacleElement = GetRandomElement();

            stackedGameMessage = $"A {currentObstacle} of type {obstacleElement} approaches you.";
            stackedGameMessage += "\n\n1 - Engage\n2 - Flee";
            UIGameLoop(stackedGameMessage);

            do
            {
                playerInput = Console.ReadLine();
            
                if (playerInput != "1" && playerInput != "2")
                                    
                    stackedGameMessage += "\n\nPlease enter a valid input";
                    UIGameLoop(stackedGameMessage);
                
            } while (playerInput != "1" && playerInput != "2");

            if (playerInput == "1")
            {
                stackedGameMessage = "You've choosen to fight";
                
                AnimationSpinner("Engaging...");

                FightOutcome fightOutcome = GetWinner(playerElement, obstacleElement);

                stackedGameMessage += $"\n\nPlayer's element: {playerElement}";
                stackedGameMessage += "\n-------------";
                stackedGameMessage += $"\nObstacle: {currentObstacle}";
                stackedGameMessage += $"\nObatacle's element: {obstacleElement}";
                stackedGameMessage += "\n-------------";
                stackedGameMessage += $"\nWINNER: {fightOutcome}";

                if (fightOutcome == FightOutcome.Player)
                {
                    playerCoins += 1;
                    playerHealth += 2;
                    currentRound++;
                }
                else if (fightOutcome == FightOutcome.Obstacle)
                {
                    playerHealth = 0;
                    isGameOver = true;
                }
                else if (fightOutcome == FightOutcome.Draw)
                {
                    playerHealth -= 5;
                    if (playerHealth < 0)
                        playerHealth = 0;

                    currentRound++;
                    playerElement = GetElementNone();
                    stackedGameMessage += "\n\nYou've lost your element";
                }

                if (playerHealth <= 0)
                {
                    isGameOver = true;
                    stackedGameMessage += "\n\nYOU DIED";   
                }
                UIGameLoop(stackedGameMessage);
            }
            else if (playerInput == "2")
            {
                currentRound++;
                playerHealth -= 5;
                stackedGameMessage = "You've choosen to flee";
                stackedGameMessage += "You've lost 5hp";

                if (playerHealth <= 0)
                {
                    isGameOver = true;
                    stackedGameMessage += "\n\nYOU DIED";   
                }

                UIGameLoop(stackedGameMessage);
            }

            playerInput = Console.ReadLine();

        } while (!isGameOver);
    }

    private String ParseElementToString(Element element)
    {
        string stringElement = "";
        switch (element)
        {
            case Element.Fire:
                stringElement = "Fire";
                break;
            case Element.Water:
                stringElement = "Water";
                break;
            case Element.Ice:
                stringElement = "Ice";
                break;
            case Element.None:
                stringElement = "None";
                break;
        }
        return stringElement;
    }

    private String ParseObstacleToString(Obstacle obstacle)
    {
        string stringObstacle = "";
        switch (obstacle)
        {
            case Obstacle.Column:
                stringObstacle = "Column";
                break;
            case Obstacle.Wall:
                stringObstacle = "Wall";
                break;
            case Obstacle.Bat:
                stringObstacle = "Bat";
                break;
            case Obstacle.Skull:
                stringObstacle = "Skull";
                break;
            case Obstacle.Trap:
                stringObstacle = "Trap";
                break;
        }
        return stringObstacle;
    }

    private Obstacle GetRandomObstacle()
    {
        Obstacle randomObstacle = Obstacle.Column;
        int randomNum = rng.Next(1, 6);
        switch (randomNum)
        {
            case 1:
                randomObstacle = Obstacle.Column;
                break;
            case 2:
                randomObstacle = Obstacle.Wall;
                break;
            case 3:
                randomObstacle = Obstacle.Bat;
                break;
            case 4:
                randomObstacle = Obstacle.Skull;
                break;                
            case 5:
                randomObstacle = Obstacle.Trap;
                break;
        }
        return randomObstacle;
    }

    private void EnterName()
    {
        AnimationSpinner("Loading", 10);
        playerName = "";
        do
        {
            Console.WriteLine("Enter your name:");
            playerName = Console.ReadLine()?.ToUpper();
            if (playerName == null || playerName == "")
                Console.WriteLine("Name cannot be empty");        
        } while (playerName == null || playerName == "");
    }

    private Element GetElementNone()
    {
        return Element.None;
    }

    private Element GetRandomElement()
    {
        int chance = rng.Next(1,4);
        Element element = Element.None;
        switch (chance)
        {
            case 1:
                element = Element.Water;
                break;
            case 2:
                element = Element.Fire;
                break;
            case 3:
                element = Element.Ice;
                break;
        }
        return element;
    }

    private FightOutcome GetWinner(Element playerElement, Element ObstacleElement)
    {
        FightOutcome fightOutcome = FightOutcome.Draw;

        if (playerElement == Element.Water)
        {
            if (ObstacleElement == Element.Fire)
            {
                fightOutcome = FightOutcome.Player;
            }
            else if (ObstacleElement == Element.Ice)
            {
                fightOutcome = FightOutcome.Obstacle;
            }
        }
        else if (playerElement == Element.Fire)
        {
            if (ObstacleElement == Element.Ice)
            {
                fightOutcome = FightOutcome.Player;
            }
            else if (ObstacleElement == Element.Water)
            {
                fightOutcome = FightOutcome.Obstacle;
            }
        }
        else if (playerElement == Element.Ice)
        {
            if (ObstacleElement == Element.Water)
            {
                fightOutcome = FightOutcome.Player;
            }
            else if (ObstacleElement == Element.Fire)
            {
                fightOutcome = FightOutcome.Obstacle;
            }
        }
        else
        {
            fightOutcome = FightOutcome.Obstacle;
        }
        return fightOutcome;
    }

    // Utilities
    private void AnimationSpinner(string text = "Loading", int rounds = 3)
    {
        string[] spinnerSrpites = ["\\", "|", "/", "-"];
        int delay = 50;

        for (int i = 0; i < rounds; i++)
        {
            for (int j = 0; j < spinnerSrpites.Length; j++)
            {
                Console.Write($"\r{text}...{spinnerSrpites[j]}");
                Delay(delay);
            }
        }
        Console.WriteLine($"\r {new String(' ', Console.BufferWidth)}");
    }

    private void Delay(int time = 100)
    {
        Thread.Sleep(time);
    }

    private void DrawLine()
    {
        Console.WriteLine("-------------------------------------------------------------------------");
    }

    private void PrintText(String text)
    {
        Console.WriteLine(text);
    }

    private void UIEmptyLine()
    {
        PrintText("\n");
    }

    private void ClearScreen()
    {
        Console.Clear();
    }

    private void UIGameIntro()
    {
        ClearScreen();
        DrawLine();
        string title = "FLAPPY ELEMENTAL - SURVIVAL RUN V2";
        PrintText(title.PadLeft(title.Length + 20));
        DrawLine();
    }

    private void UIGameLoop(String message = "")
    {
        ClearScreen();
        DrawLine();
        string stackedGameUI = "";
        int UIDefinedPadding = 15;
        if (playerName != null)
            {
                stackedGameUI = $"PLAYER: {playerName} ".PadRight(UIDefinedPadding);
                stackedGameUI += $"| ELEMENT: {ParseElementToString(playerElement)} ".PadRight(UIDefinedPadding);
                stackedGameUI += $"| HEALTH: {playerHealth}".PadRight(UIDefinedPadding);
                stackedGameUI += $"| COINS: {playerCoins}".PadRight(UIDefinedPadding);
                stackedGameUI += $"| ROUND: {currentRound}".PadRight(UIDefinedPadding);  
            }
        PrintText(stackedGameUI);
        DrawLine();
        UIEmptyLine();
        PrintText(message);
    }
}