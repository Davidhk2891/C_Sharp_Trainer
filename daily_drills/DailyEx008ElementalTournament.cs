// 1)
/*
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
*/
// 2)
/*
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
*/
public class DailyEx008ElementalTournament
{
    private string[] warriorsNames = [ "Ashveil", "Dreadmaw", "The Hollow", "Seraphon" ];
    private Element[] warriorsElements = new Element[4];
    private string[] wins = new string[4];
    private Random rng = new();
    private int globalDelay = 1000;
    
    private enum Element
    {
        Ice,
        Fire,
        Water
    }

    private enum RoundResult
    {
        
    }
    public void RunApp()
    {
        GreetRoster();
        AssignElementToWarrior();
        AnnounceRoster();
        GreetTournament();
        RunFights();
        PrintScoreBoard();
    }

    private void GreetRoster()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine("ELEMENTAL TOURNAMENT V1.0");
        DrawLine();
        Console.WriteLine("--- THE ROSTER ---");
    }

    private void GreetTournament()
    {
        Console.WriteLine("--- THE TOURNAMENT ---");
        Console.WriteLine("Let the battles begin...\n");
    }

    private void AnnounceRoster()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            Thread.Sleep(globalDelay);
            Console.WriteLine($"Warrior: {warriorsNames[i].ToUpper()} | Element: {warriorsElements[i]}");
        }
        DrawLine();
    }

    private void AssignElementToWarrior()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            warriorsElements[i] = GetRandomElement();
        }
    }

    private Element GetRandomElement()
    {
        Element element = Element.Water;
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

    private void RunFights()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            if (i == warriorsNames.Length - 1)
            {
                break;
            }
            else
            {
                Thread.Sleep(globalDelay);
                int fightNum = i + 1;
                string warriorAndElement1 = $"{warriorsNames[i].ToUpper()} ({warriorsElements[i]})";
                string warriorAndElement2 = $"{warriorsNames[i + 1].ToUpper()} ({warriorsElements[i + 1]})";
                string fight = $"Fight {fightNum}: {warriorAndElement1} vs {warriorAndElement2}";
                string fightWinner = "";
                int fightWinnerIndex = GetWinner(warriorsNames[i], warriorsNames[i + 1], warriorsElements[i], warriorsElements[i + 1]);

                if (fightWinnerIndex == i)
                {
                    wins[i] = $"Fight {fightNum}: {warriorsNames[i]} def. {warriorsNames[i + 1]}";
                    fightWinner = $"→ {warriorsNames[i]} wins!";
                }
                else if (fightWinnerIndex == i + 1)
                {
                    wins[i] = $"Fight {fightNum}: {warriorsNames[i + 1]} def. {warriorsNames[i]}";   
                    fightWinner = $"→ {warriorsNames[i + 1]} wins!";
                }
                else
                {
                    wins[i] = $"Fight {fightNum}: {warriorsNames[i]} tied with {warriorsNames[i + 1]}";   
                    fightWinner = $"→ {warriorsNames[i]} tied with {warriorsNames[i + 1]}";
                }

                Console.WriteLine(fight);
                Console.WriteLine(fightWinner);
                DrawLine();   
            }
        }
    }

    private void PrintScoreBoard()
    {
        Console.WriteLine("--- THE SCOREBOARD ---");
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            Console.WriteLine(wins[i]);
        }
    }
    private int GetWinner(string warrior1, string warrior2, Element elementWarrior1, Element elementWarrior2)
    {   
        String draw = "Draw";

        string winner = "";

        int winnerIndex;

        if (elementWarrior1 == Element.Ice)
        {
            if (elementWarrior2 == Element.Water) winner = warrior1;
            else if (elementWarrior2 == Element.Fire) winner = warrior2;
            else winner = draw;
        }
        else if (elementWarrior1 == Element.Water)
        {
            if (elementWarrior2 == Element.Fire) winner += warrior1;
            else if (elementWarrior2 == Element.Ice) winner += warrior2;
            else winner = draw;
        }
        else if (elementWarrior1 == Element.Fire)
        {
            if (elementWarrior2 == Element.Ice) winner += warrior1;
            else if (elementWarrior2 == Element.Water) winner += warrior2;
            else winner = draw;
        }

        if (winner == warriorsNames[0]) winnerIndex = 0;
        else if (winner == warriorsNames[1]) winnerIndex = 1;
        else if (winner == warriorsNames[2]) winnerIndex = 2;
        else if (winner == warriorsNames[3]) winnerIndex = 3;
        else winnerIndex = -1;

        return winnerIndex;
    }

    private void DrawLine()
    {
        Console.WriteLine("------------------------");
    }
}