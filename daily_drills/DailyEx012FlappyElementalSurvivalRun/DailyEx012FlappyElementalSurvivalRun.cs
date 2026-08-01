public class DailyEx012FlappyElementalSurvivalRun
{
    /*
    1. Define fields, methods
    2. Build core methods
    3. Build core game loop
        a. Loop that does the following:
            - You start naked
            - 3 seconds pass (anim)
            - Game asks if you want to grab a new chip (random)
            - Grab it or not, after 3 more seconds (anim), obstacle appears
            - Game warns an obstacle of element X appears
            - Engage or dodge
                - If engage and win, you win something and move one
                - If engage and lose (RPS system), game over
                - If dodge, lose element and move on
            - Repeat until you die
    4. Build 'rounds survived' system
    5. Build advanced UI
    */

    private void BeginRun()
    {
        string accept = "1";
        string deny = "2";
        int playerHP = 5;
        int roundsSurvived = 0;
        bool isGameOver = false;
        string currentMessage = "";
        string invalidInput = "Invalid input. Please try again";
        Obstacle randomObstacleType;
        Element randomObstacleElement;
        string playerName = "david".ToUpper();
        Element playerElement = AssignNoneElement();
        Element randomElement = AssignNoneElement();

        do
        {            
            // Request new chip (optional)
            randomElement = GetRandomElement();
            currentMessage = $"A {randomElement} chip is nearby. Grab it? ({accept}-Yes / {deny}-No)";
            do
            {
                AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage, roundsSurvived + 1);
                playerInput = Console.ReadLine();

                if (playerInput != accept && playerInput != deny)
                    Console.WriteLine("Invalid input. Please try again");

            } while (playerInput != accept && playerInput != deny);

            if (playerInput == accept)
            {
                playerElement = randomElement;
                currentMessage = $"You grabbed {ParseElementToReadable(playerElement)}!";
            }
            else
            {
                currentMessage = $"Your current element is {ParseElementToReadable(playerElement)}";
            }                   
        
            AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage,  roundsSurvived + 1);

            RunAnimationSpinner();

            randomObstacleType = GetRandomObstacle();
            randomObstacleElement = GetRandomElement();
            // Warn player of incoming obstacle
            currentMessage = $"A {randomObstacleType} of type {randomObstacleElement} approaches!\n\n";
            AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage,  roundsSurvived + 1);
            // LEFT HERE
            playerInput = null;
            currentMessage += $"Do you want to engage? ({accept}-Engage / {deny}-Dodge)";
            while (playerInput == null || (playerInput != accept && playerInput != deny))
            {
                // Ask player if he wants to engage or not
                AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage,  roundsSurvived + 1);
                playerInput = Console.ReadLine();

                if (playerInput == null || (playerInput != accept && playerInput != deny))
                    Console.WriteLine("Invalid input. Please try again");
            }
            
            if (playerInput == accept)
            {     
                currentMessage =                     
                    "You chose to engage the obstacle\n" +
                    "---\n" +
                    $"Your element: {playerElement}\n" +
                    $"{randomObstacleType} element: {randomObstacleElement}\n" +
                    "---\n";
                AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage,  roundsSurvived + 1);
                RunAnimationSpinner("Engaging");

                Entity encounterWinner = GetWinner(playerElement, randomObstacleElement);
                if (encounterWinner != Entity.None)
                {
                    currentMessage += $"{encounterWinner} wins\n\n";                    
                    if (encounterWinner == Entity.Obstacle)
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        roundsSurvived++;
                        currentMessage += $"Round survived";                        
                    }
                }
                else
                {
                    currentMessage += 
                        $"Draw!\n\n" +
                        $"You lost your {playerElement} element\n\n" +
                        $"Round survived";
                    
                    roundsSurvived++;
                    playerElement = AssignNoneElement();                    
                }
            }
            else
            {
                RunAnimationSpinner();
                currentMessage = 
                    "You chose to dodge the obstacle. You lose 1 HP\n\n" +
                    "Round survived";
                roundsSurvived++;
                playerHP -= 1;
            }

            if (playerHP <= 0)
            {
                isGameOver = true;    
            }
            else
            {
                currentMessage += "\n\nPress any key to continue";
                AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage, roundsSurvived + 1);
                playerInput = Console.ReadLine();
            }
            

        } while (!isGameOver);

        if (isGameOver)
        {            
            currentMessage = 
                "\nGAME OVER\n\n" +
                $"Total rounds survived: {roundsSurvived}";
            AlwaysPrintTopHeader(playerName, ParseElementToReadable(playerElement), playerHP, currentMessage, roundsSurvived + 1);
        }            
    }

    private void AlwaysPrintTopHeader(string playerName, string playerElement, int playerHP, string message, int roundsSurvived)
    {
        Console.Clear();
        int padTopInfo = 10;
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine(
            $"{playerName.PadRight(padTopInfo)}|" +
            $"Element: {playerElement.ToString().PadRight(padTopInfo)}|" +
            $"HP: {playerHP.ToString().PadRight(padTopInfo)} |" +
            $"Round: {roundsSurvived}");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine(message);
        Console.WriteLine("--------------------------------------------------------");
    }

    private Random rng = new();
    private string? playerInput = "";

    public void RunApp()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("FLAPPY ELEMENTAL - SURVIVAL RUN".PadLeft(45));
        Console.WriteLine("--------------------------------------------------------");
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
            else
                outcome = Entity.None;
        }
        else if (playerElement == Element.Fire)
        {
            if (obstacleElement == Element.Ice)
                outcome = Entity.Player;
            else if (obstacleElement == Element.Water)
                outcome = Entity.Obstacle;
            else
                outcome = Entity.None;
        }
        else if (playerElement == Element.Ice)
        {
            if (obstacleElement == Element.Water)
                outcome = Entity.Player;
            else if (obstacleElement == Element.Fire)
                outcome = Entity.Obstacle;
            else
                outcome = Entity.None;
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

    private void PrintEmptyLine()
    {
        Console.WriteLine();
    }
}