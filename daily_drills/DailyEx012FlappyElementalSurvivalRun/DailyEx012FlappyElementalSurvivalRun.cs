public class DailyEx012FlappyElementalSurvivalRun
{
    /*
    1. Define fields, methods
    2. Build core methods
    3. Build core game loop
        a. Loop that does the following:
            - You start naked
            - 3 seconds pass (anim)
            - Game asks if you want to grab a chip (random)
            - Grab it or not, after 3 more seconds (anim), obstacle appears
            - Game warns an obstacle of element X appears
            - Engage or dodge
                - If engage and win, you win something and move one
                - If engage and lose (RPS system), game over
                - If dodge, lose element and move on
            - Repeat until you die
    */

    private void BeginRun()
    {
        Element playerElement = Element.None;
        string accept = "y";
        string deny = "n";
        int playerHP = 5;
        bool isGameOver = false;
        string invalidInput = "Invalid input. Please try again";
        Obstacle randomObstacleType;
        Element randomObstacleElement;

        // Assign element to player
        do
        {
            Console.WriteLine($"Do you want to grab a chip? ({accept}/{deny})");
            playerInput = Console.ReadLine();

            if (playerInput != accept && playerInput != deny)
                Console.WriteLine("Invalid input. Please try again");

        } while (playerInput != accept && playerInput != deny);

        if (playerInput == accept)
            playerElement = GetRandomElement();   
        
        Console.WriteLine($"Your element is: {ParseElementToReadable(playerElement)}");

        RunAnimationSpinner();

        do
        {
            randomObstacleType = GetRandomObstacle();
            randomObstacleElement = GetRandomElement();
            // Warn player of incoming obstacle
            Console.WriteLine($"A {randomObstacleType} of type {randomObstacleElement} appears");
            playerInput = null;
            while (playerInput == null || (playerInput != accept && playerInput != deny))
            {
                // Ask player if he wants to engage or not
                Console.WriteLine($"Do you want to engage? ({accept}/{deny})");
                playerInput = Console.ReadLine();

                if (playerInput == null || (playerInput != accept && playerInput != deny))
                    Console.WriteLine("Invalid input. Please try again");
            }

            PrintFullDottedLine();
            
            if (playerInput == accept)
            {
                Console.WriteLine("You chose to engage the obstacle");
                Console.WriteLine($"Your element: {playerElement}");
                Console.WriteLine($"{randomObstacleType} element: {randomObstacleElement}");
                RunAnimationSpinner("Engaging");
                PrintFullDottedLine();

                Entity encounterWinner = GetWinner(playerElement, randomObstacleElement);
                if (encounterWinner != Entity.None)
                {
                    Console.WriteLine($"{encounterWinner} wins");
                    if (encounterWinner == Entity.Obstacle)
                    {
                        playerHP -= 1;
                    }
                    Console.WriteLine($"Your current HP is {playerHP}");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
            else
            {
                RunAnimationSpinner();

                PrintFullDottedLine();
                Console.WriteLine("You chose to dodge the obstacle. You lose 1 HP");
                playerHP -= 1;
                Console.WriteLine($"Your current HP is {playerHP}");
                PrintFullDottedLine();
            }

            PrintFullDottedLine();

            if (playerHP <= 0)
                isGameOver = true;

        } while (!isGameOver);

        if (playerHP <= 0)
            Console.WriteLine("GAME OVER");
    }

    private Random rng = new();
    private string? playerInput = "";

    public void RunApp()
    {
        Console.Clear();
        Console.WriteLine("FLAPPY ELEMENTAL - SURVIVAL RUN");
        RunAnimationSpinner();
        BeginRun();
    }

    private enum Element
    {
        Water,
        Fire,
        Ice,
        None
    }

    private enum Engagement
    {
        Win,
        Draw,
        Lose,
        Skip
    }

    private enum Entity
    {
        Player,
        Obstacle,
        None
    }

    private enum Obstacle
    {
        Batty,
        Waller,
        Spinner,
        Bitter
    }

    private Obstacle GetRandomObstacle()
    {
        Obstacle obstacle = Obstacle.Batty;
        int randomIndex = rng.Next(1, 5);
        switch (randomIndex)
        {
            case 1:
                obstacle = Obstacle.Batty;
                break;
            case 2:
                obstacle = Obstacle.Waller;
                break;
            case 3:
                obstacle = Obstacle.Spinner;
                break;
            case 4:
                obstacle = Obstacle.Bitter;
                break;
        }
        return obstacle;
    }

    private Element GetRandomElement()
    {
        int randomIndex = rng.Next(1, 4);
        Element randomElement = Element.None;
        switch (randomIndex)
        {
            case 1:
                randomElement = Element.Water;
                break;
            case 2:
                randomElement = Element.Fire;
                break;
            case 3:
                randomElement = Element.Ice;
                break;
        }
        return randomElement;
    }

    private string ParseElementToReadable(Element element)
    {
        string output;
        switch (element)
        {
            case Element.Water:
                output = "Water";
                break;
            case Element.Fire:
                output = "Fire";
                break;
            case Element.Ice:
                output = "Ice";
                break;
            default:
                output  = "None";
                break;
        }
        return output;
    }

    private Element AssignNoneElement()
    {
        return Element.None;
    }

    private Entity GetWinner(Element playerElement, Element obstacleElement)
    {
        Entity outcome = Entity.None;
        if (playerElement == Element.Water)
        {
            if (obstacleElement == Element.Fire)
                outcome = Entity.Player;
            else if (obstacleElement == Element.Ice)
                outcome = Entity.Obstacle;
                // Account for draw <-- LEFT HERE
        }
        else if (playerElement == Element.Fire)
        {
            if (obstacleElement == Element.Ice)
                outcome = Entity.Player;
            else if (obstacleElement == Element.Water)
                outcome = Entity.Obstacle;
        }
        else if (playerElement == Element.Ice)
        {
            if (obstacleElement == Element.Water)
                outcome = Entity.Player;
            else if (obstacleElement == Element.Fire)
                outcome = Entity.Obstacle;
        }
        else
        {
            // If player has no element
            outcome = Entity.Obstacle;
        }
        return outcome;
    }

    // Utilities
    private void RunAnimationSpinner(string text = "Loading", int rounds = 10)
    {
        string[] spinningSymbols = [ "\\", "|", "/", "-" ];
        int delay = 50;

        for (int i = 0; i < rounds; i++)
        {
            for (int j = 0; j < spinningSymbols.Length; j++)
            {
                Console.Write($"\r {text}...{spinningSymbols[j]}");
                Delay(delay);
            }               
        }
        Console.WriteLine($"\r {new String(' ', Console.BufferWidth)}");
    }

    private void Delay(int delay = 100)
    {
        Thread.Sleep(delay);
    }

    private void PrintFullDottedLine()
    {
        Console.WriteLine("--------------------");
    }

    private void PrintEmptyLine()
    {
        Console.WriteLine();
    }
}