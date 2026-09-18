/*
    Premise:
        - The training simulation continues. This time the duel is automatede. You pick your element once, then watch fate play out over 5 rounds
    
    Setup:
        - Three elements: Ice, Fire, Water
        - Win conditions: Water beat Fire, Fire beats Ice, Ice beats Water
        - Fixed 5 rounds, no prompts between rounds
        - Use enum Element and enum RoundResult instead of strings
    
    Rules:
        - Declare enum Element { Fire, Water, Ice } and enum RoundResult { Player, Enemy, Draw }
        - Write GetWinner(Element player, Element enemy) -> returns a RoundResult
        - Write GetRandomElement() -> returns an Element
        - Player picks element once at the start (1,2,3)
        - Invalid input -> Sneer and re-prompt
        - Game auto-plays all 5 rounds
        - Print each round: round number, both elements, who won 
        - After 5 rounds print match summary and overall winner
*/
public class DailyEx006ElementalDuelV2
{
    bool quitGame = false;
    bool invalidInput = false;
    int totalMatches = 1;
    int totalRounds = 5;
    int currentRound = 0;
    int playerWins = 0;
    int enemyWins = 0;
    int draws = 0;
    Element playerChosenElement = Element.None;
    Element enemyChosenElement = Element.None;
    RoundResult winner;
    readonly Random rng = new();
    public void RunApp()
    {
        Play();
    }

    private enum Element
    {
        Fire,
        Water,
        Ice,
        None
    }

    private enum RoundResult
    {
        Player,
        Enemy,
        Draw
    }

    private void Play()
    {
        GreetPlayer();
        if (!quitGame)
            RunMatches(totalMatches);
    }

    private void GreetPlayer()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine("ELEMENTAL DUEL V2");
        DrawLine();
        PlayerSelectElement();
    }

    private void RunMatches(int matches)
    {
        for (int i = 0; i < matches; i++)
        {
            RunRounds(totalRounds);   
        }
        MatchSummary();
    }

    private void MatchSummary()
    {
        Console.WriteLine($"---- Match summary ----");
        Console.WriteLine($"Player wins: {playerWins}");
        Console.WriteLine($"Enemy wins: {enemyWins}");
        Console.WriteLine($"Draws: {draws}");

        RoundResult matchWinner;
        if (playerWins > enemyWins) matchWinner = RoundResult.Player;
        else if (playerWins < enemyWins) matchWinner = RoundResult.Enemy;
        else matchWinner = RoundResult.Draw;
        Console.WriteLine($"Match winner: {matchWinner}");
    }

    private void RunRounds(int rounds)
    {
        for (int i = 1; i <= rounds; i++)
        {
            currentRound = i;
            Console.WriteLine($"----- Round {currentRound} -----");
            EnemySelectElement();
            Console.WriteLine($"You chose {playerChosenElement}");
            Console.WriteLine($"Enemy chose {enemyChosenElement}");
            winner = GetWinner(playerChosenElement, enemyChosenElement);
            Console.WriteLine($"Round {i} winner: {winner}");
            DrawLine();
            Thread.Sleep(1000);
        }
    }

    private void PlayerSelectElement()
    {
        do
        {
            Console.WriteLine("Pick your element:\n1 - Ice\n2 - Water\n3 - Fire\nQ - Quit");
            DrawLine();
            string? option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    playerChosenElement = Element.Ice;
                    invalidInput = false;
                    break;
                case "2":
                    playerChosenElement = Element.Water;
                    invalidInput = false;
                    break;
                case "3":
                    playerChosenElement = Element.Fire;
                    invalidInput = false;
                    break;
                case "q":
                    QuitGame();
                    break;
                default:
                    InvalidInput();
                    break;
            }
            DrawLine();   
        } while (invalidInput && !quitGame);
    }

    private void EnemySelectElement()
    {
        enemyChosenElement = GetRandomElement();
    }

    private RoundResult GetWinner(Element player, Element enemy)
    {
        RoundResult winner = RoundResult.Draw;
        if (player == Element.Water)
        {
            if (enemy == Element.Fire) winner = RoundResult.Player;
            else if (enemy == Element.Ice) winner = RoundResult.Enemy;
        }
        else if (player == Element.Fire)
        {
            if (enemy == Element.Ice) winner = RoundResult.Player;
            else if (enemy == Element.Water) winner = RoundResult.Enemy;
        }
        else if (player == Element.Ice)
        {
            if (enemy == Element.Water) winner = RoundResult.Player;
            else if (enemy == Element.Fire) winner = RoundResult.Enemy;
        }

        if (winner == RoundResult.Player) playerWins++;
        else if (winner == RoundResult.Enemy) enemyWins++;
        else if (winner == RoundResult.Draw) draws++;
        return winner;
    }

    private Element GetRandomElement()
    {
        Element randomElement = Element.None;
        int randomElementIndex = rng.Next(1, 4);
        switch (randomElementIndex)
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

    private void QuitGame()
    {
        Console.WriteLine("Good bye.");
        quitGame = true;
    }

    private void InvalidInput()
    {
        Console.WriteLine("Invalid input");
        invalidInput = true;
    }   

    private void DrawLine()
    {
        Console.WriteLine("----------------------");
    }
}