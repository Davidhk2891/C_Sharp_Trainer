/*
1)
    Premise:
        - Before the tournament begins, the arena master reveals the roster. Four warriors
        enter. Each is randomly assigned an element. The crowd watches in silence as each name is called.
    
    Setup:
        - Four harcoded player names stored in a string array
        - Each player is randomly assigned an Element using GetRandomElement()
        - Names revealed one at a time with a pause between each

    Rules:
        - Declare a string[] of 4 hardcoded player names
        - Declare an Element[] of 4 elements, assigned via GetRandomElement()
        - Use a for loop to assign and print each player's name and element
        - Print names in ALL CAPS using ToUpper()
        - Use Thread.Sleep(1000) between each reveal
        - Reuse your Element enum and GetRandomElement() method from previous exercises

    Exepcted output
    --- THE ROSTER ---
    ASHVEIL - Fire
    DREADMAW - Water
    THE HOLLOW - Ice
    SERAPHON - Fire

2)
    Premise:
        - The roster is set. Now the warriors fight. Each warrior faces the next one in line. The results are recorded and a scoreboard is printed at the end.

    Setup:

        - Use the same 4 warriors and their assigned elements from the roster
        - Each warrior fights the next one: 0v1, 1v2, 2v3
        - Results are stored in a string array
        - Print the scoreboard after all fights

    Rules:

        - Reuse Element enum, GetRandomElement(), and GetWinner() from previous exercises
        - Store fighter names and their elements in parallel arrays
        - Run 3 fights: warrior[0] vs warrior[1], warrior[1] vs warrior[2], warrior[2] vs warrior[3]
        - Store each fight result as a string in a string[] results array — format: "ASHVEIL def. DREADMAW"  or "Draw"
        - Use modulus to print a divider line every 2 fights
        - Use a ternary operator at least once for result formatting
        - Print the full scoreboard at the end

    Expected output:
        --- THE TOURNAMENT ---
        Fight 1: ASHVEIL (Fire) vs DREADMAW (Water)
        → DREADMAW wins!
        --------------------
        Fight 2: DREADMAW (Water) vs THE HOLLOW (Ice)
        → DREADMAW wins!
        Fight 3: THE HOLLOW (Ice) vs SERAPHON (Fire)
        → THE HOLLOW wins!
        --------------------
        --- SCOREBOARD ---
        Fight 1: DREADMAW def. ASHVEIL
        Fight 2: DREADMAW def. THE HOLLOW
        Fight 3: THE HOLLOW def. SERAPHON

3) 
    🧊🔥💧 The Hall of Fame
    Premise:
        - The tournament is over. The arena master tallies the wins and enshrines every warrior in the Hall of Fame — win or lose. Their record stands forever.

    Setup:
        - Same 4 warriors and elements as before
        - Run the same 3 fights
        - Track win counts per warrior in a 2D array
        - Print the Hall of Fame at the end

    Rules:
        - Reuse Element enum, GetRandomElement(), GetWinner() from previous exercises
        - Use a 2D array: string[,] hallOfFame = new string[4, 2]
        - hallOfFame[i, 0] = warrior name, hallOfFame[i, 1] = win count as string
        - After all fights, loop through hallOfFame and print each warrior's name and win count
        - Use modulus to print a divider every 2 fights during the tournament
        - Use a ternary at least once for result formatting
        - A draw counts as 0 wins for both warriors
    
    Output:
        --- HALL OF FAME ---
        ASHVEIL — 0 wins
        DREADMAW — 1 win
        THE HOLLOW — 2 wins
        SERAPHON — 0 wins
*/

public class DailyEx009ElementalHallOfFame
{
    private static int DELAY_ROSTER = 1000;
    private static int DELAY_DUELS = 1000;
    private static int DELAY_SCOREBOARD = 700;
    private static int DELAY_HALL_OF_FAME = 700;
    private static string DRAW = "Draw!";
    private string[] warriorsNames = [ "Ashveil", "Dreadmaw", "The Hollow", "Seraphon" ];
    private Element[] warriorsElements = new Element[4];
    private string[] warriorsFightResults = new string[3];
    private string[,] warriorsHallOfFame = new string[4, 2];
    private Random rng = new();
    private int winnerIndex;
    int counter0 = 0, counter1 = 0, counter2 = 0, counter3 = 0;
    private enum Element
    {
        Ice,
        Water,
        Fire
    }
    public void RunApp()
    {
        GreetRoster();
        AssignElementToWarriors();
        AddNamesToHOFWarriors();
        RunRoster();

        GreetTournament();
        RunBattles();

        GreetScoreboard();
        PrintScoreBoard();

        GreetHallOfFame();
        PrintHallOfFame();
    }

    private void GreetRoster()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine("---- THE ROSTER ----");
        DrawLine();
    }

    private void GreetTournament()
    {
        DrawLine();
        Console.WriteLine("-- THE TOURNAMENT --");
        DrawLine();
    }

    private void GreetScoreboard()
    {
        DrawLine();
        Console.WriteLine("-- THE SCOREBOARD --");
        DrawLine();
    }

    private void GreetHallOfFame()
    {
        DrawLine();
        Console.WriteLine("--- HALL OF FAME ---");
        DrawLine();
    }

    private void AddNamesToHOFWarriors()
    {
        for (int i = 0; i < warriorsHallOfFame.GetLength(0); i++)
        {
            warriorsHallOfFame[i, 0] = warriorsNames[i];
            warriorsHallOfFame[i, 1] = "0";
        }
    }

    private void AddWinsToWarriors(int winnerIndex)
    {
        switch (winnerIndex)
        {
            case 0:
                warriorsHallOfFame[0, 1] = (++counter0).ToString();
                break;
            case 1:
                warriorsHallOfFame[1, 1] = (++counter1).ToString();
                break;
            case 2:
                warriorsHallOfFame[2, 1] = (++counter2).ToString();
                break;
            case 3:
                warriorsHallOfFame[3, 1] = (++counter3).ToString();
                break;
            case -1:
                break;
        }
    }

    private void PrintHallOfFame()
    {
        for (int i = 0; i < warriorsHallOfFame.GetLength(0); i++)
        {
            DelayAction(DELAY_HALL_OF_FAME);
            Console.WriteLine($"{warriorsHallOfFame[i, 0]} - {warriorsHallOfFame[i, 1]} wins");
        }
    }

    private void RunBattles()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            if (i == warriorsElements.Length - 1) break;
            
            DelayAction(DELAY_DUELS);
            string warriorWithElement1 = $"{warriorsNames[i].ToUpper()} ({warriorsElements[i]})";
            string warriorWithElement2 = $"{warriorsNames[i + 1].ToUpper()} ({warriorsElements[i + 1]})";
            Console.WriteLine($"Fight {i}: {warriorWithElement1} vs {warriorWithElement2}");
            winnerIndex = GetWinner(warriorsNames[i], warriorsElements[i], warriorsNames[i + 1], warriorsElements[i + 1]);
            string winnerName = "";
            string winnerText = "";
            switch (winnerIndex)
            {
                case 0:
                    winnerName = warriorsNames[0];
                    break;
                case 1:
                    winnerName = warriorsNames[1];
                    break;
                case 2:
                    winnerName = warriorsNames[2];
                    break;
                case 3:
                    winnerName = warriorsNames[3];
                    break;
                case -1:
                    winnerName = DRAW;
                    break;
            }
            
            if (winnerName != DRAW)
                winnerText = $"→ {winnerName.ToUpper()} wins!";
            else
                winnerText = winnerName;
            Console.WriteLine(winnerText);
            DrawLine();   
            if (winnerName.Equals(warriorsNames[i]))
                warriorsFightResults[i] = $"Fight {i + 1}: {warriorsNames[i].ToUpper()} def. {warriorsNames[i + 1].ToUpper()}";
            else if (winnerName.Equals(warriorsNames[i + 1]))
                warriorsFightResults[i] = $"Fight {i + 1}: {warriorsNames[i + 1].ToUpper()} def. {warriorsNames[i].ToUpper()}";
            else
                warriorsFightResults[i] = $"Fight {i + 1}: {warriorsNames[i].ToUpper()} tied with {warriorsNames[i + 1].ToUpper()}";
            
            AddWinsToWarriors(winnerIndex);
        }
        DrawShortLine();
    }

    private void PrintScoreBoard()
    {
        for (int i = 0; i < warriorsFightResults.Length; i++)
        {
            DelayAction(DELAY_SCOREBOARD);
            Console.WriteLine(warriorsFightResults[i]);
        }
        DrawShortLine();
    }

    private void RunRoster()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            DelayAction(DELAY_ROSTER);
            string warriorWithElement = $"Warrior: {warriorsNames[i].ToUpper()} | Element: {warriorsElements[i]}";
            Console.WriteLine(warriorWithElement);
        }
        DrawShortLine();
        Console.WriteLine("Let the duels begin...");
    }

    private void AssignElementToWarriors()
    {
        for (int i = 0; i < warriorsElements.Length; i++)
        {
            warriorsElements[i] = GetRandomElement();
        }
    }

    private int GetWinner(string warriorName1, Element warriorElement1, string warriorName2, Element warriorElement2)
    {
        int winnerIndex = -1;
        string winnerName = DRAW;
        
        if (warriorElement1 == Element.Ice)
        {
            if (warriorElement2 == Element.Water) winnerName = warriorName1;
            else if (warriorElement2 == Element.Fire) winnerName = warriorName2;
        }
        else if (warriorElement1 == Element.Water)
        {
            if (warriorElement2 == Element.Fire) winnerName = warriorName1;
            else if (warriorElement2 == Element.Ice) winnerName = warriorName2;
        }
        else if (warriorElement1 == Element.Fire)
        {
            if (warriorElement2 == Element.Ice) winnerName = warriorName1;
            else if (warriorElement2 == Element.Water) winnerName = warriorName2;
        }

        if (winnerName == warriorsNames[0]) winnerIndex = 0;
        else if (winnerName == warriorsNames[1]) winnerIndex = 1;
        else if (winnerName == warriorsNames[2]) winnerIndex = 2;
        else if (winnerName == warriorsNames[3]) winnerIndex = 3;
        else winnerIndex = -1;

        return winnerIndex;
    }

    private Element GetRandomElement()
    {
        Element element = Element.Ice;
        int elementIndex = rng.Next(1, 4);
        switch (elementIndex)
        {
            case 1:
                element = Element.Ice;
                break;
            case 2:
                element = Element.Water;
                break;
            case 3:
                element = Element.Fire;
                break;
        }
        return element;
    }

    private void DelayAction(int delay)
    {
        Thread.Sleep(delay);
    }

    private void DrawShortLine()
    {
        Console.WriteLine("----");
    }

    private void DrawLine()
    {
        Console.WriteLine("--------------------");
    }
}