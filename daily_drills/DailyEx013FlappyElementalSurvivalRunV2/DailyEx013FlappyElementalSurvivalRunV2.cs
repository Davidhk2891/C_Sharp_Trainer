/*
Premise:
    - You are a flyer entering the gauntlet. Type your name, pick a starting element,
        and survive as many rounds as possible against incoming elemental obstacles.
Setup:
    - Player types the name at the start
    - Player gets a random element
    - Each round: Random obstacle with random element appears
    - Player grabs a chip or skipsm then engages or dodges
    - 5 HP. Game ends at 0
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

public class DailyEx013FlappyElementalSurvivalRunV2
{
    private Random rng = new();
    public void RunApp()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine("DailyEx013FlappyelementalSurvivalRun V2");
        DrawLine();
        BeginRun();
    }

    private enum Element
    {
        Water,
        Fire,
        Ice,
        None
    }

    private enum FightOutcome
    {
        Player,
        Obstacle,
        Draw
    }

    private void BeginRun()
    {
        AnimationSpinner("Loading", 10);
        // string? playerInput = "";
        // do
        // {
        //     Console.WriteLine("Enter your name:");
        //     playerInput = Console.ReadLine();
        //     if (playerInput == null || playerInput == "")
        //         Console.WriteLine("Name cannot be empty");
    
            
        // } while (playerInput == null || playerInput == "");
    }

    private Element AssignElementNone()
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
        Console.WriteLine("---------------------------------------");
    }
}