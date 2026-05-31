/*
Premise:
the arena master receieves a new scroll. This time it contains warrior names only. No elements.
 Elements must be assigned randomly. After 3 duels, the results are compiles into a ranked report string and
 announced to the crowd.

Setup:
Warrior data: "Seraphon, Ashveil, The Hollow, Dreadmaw"
Names arraive unsorted. Sort them alphabetically before assigning elements
Each warrior gets a random element
Run 3 duels: 0v1, 1v2, 2v3

Rules:
- Use Split(',') to parse names, then Array.Sort() to sort them
- GetRandomElement() and GetWinner() from memory
- Store each duel result as a string in a results array
- Use String.Join("\n", resultsArray) to build the final report
- Use a ternary to format each result line
- User modulus to show a spinner animation every 2nd fight only
- Print the final joined report at the end

*/
using System.Runtime.InteropServices;

public class DailyEx011TheRankedCodex
{
    // 1. Declare fields - DONE
    // 2. Sort scroll alphabetically - DONE
    // 3. Declare Element enum - DONE
    // 4. Define GetRandomElement() - DONE
    // 5. Define GetWinner() - DONE
    // 6. Run 3 duels

    private Random rng = new();
    private static readonly int TOTAL_FIGHTS = 3;
    private static int ROUNDS_PER_FIGHT = 3;
    private string[] fightResults = new string[ROUNDS_PER_FIGHT];
    public void RunApp()
    {
        Console.Clear();

        string scroll = "Seraphon, Ashveil, The Hollow, Dreadmaw";

        string[] scrollNames = scroll.Split(",");
        Element[] scrollElements = new Element[4];
        
        SetWarriorNames(scrollNames);
        SetWarriorElements(scrollElements);
        PrintWarriorsAndElements(scrollNames, scrollElements);
        RunDuels(scrollNames, scrollElements);
    }

    private enum Element
    {
        Water,
        Fire,
        Ice,
        None
    }

    private void SetWarriorNames(string[] scrollNames)
    {
        Array.Sort(scrollNames);
        for (int i = 0; i < scrollNames.Length; i++)
        {
            scrollNames[i] = scrollNames[i].Trim();
        }
    }

    private void SetWarriorElements(Element[] scrollElements)
    {
        for (int i = 0; i < scrollElements.Length; i++)
        {
            scrollElements[i] = GetRandomElement();
        }
    }

    private Element GetRandomElement()
    {
        int elementSelector = rng.Next(1, 4);
        Element element = Element.None;
        switch (elementSelector)
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

    private void RunDuels(string[] scrollNames, Element[] scrollElements)
    {
        // - Store each duel result as a string in a results array - DONE
        // - Use String.Join("\n", resultsArray) to build the final report
        // - Use a ternary to format each result line - DONE
        // - User modulus to show a spinner animation every 2nd fight only - DONE
        // - Print the final joined report at the end
        for (int i = 0; i < scrollNames.Length - 1; i++)
        {

            Console.WriteLine($"\nFight {i + 1} | {scrollNames[i]} VS {scrollNames[i + 1]}\n");
            string fightResult = "";
            string[] roundWinnerCount = new string[ROUNDS_PER_FIGHT];

            for (int j = 1; j <= ROUNDS_PER_FIGHT; j++)
            {
                if (j > 1)
                    SetWarriorElements(scrollElements);

                string roundIntro = $"Round {j} | {scrollNames[i]}({scrollElements[i]})" +
                 $" VS {scrollNames[i + 1]}({scrollElements[i + 1]})\n";
                fightResult += roundIntro;
                
                string roundResult = "Round winner: " +
                    $"{GetRoundWinner(scrollNames[i], scrollElements[i], scrollNames[i + 1], scrollElements[i + 1])}";
                roundResult += j < ROUNDS_PER_FIGHT ? "\n\n" : "\n";
                fightResult += roundResult;
                roundWinnerCount[j - 1] = ExtractRoundWinner(roundResult);
            }
            fightResults[i] = fightResult;
            Console.WriteLine(fightResult);
            DrawShortLine();
            Console.Write($"Fight winner: {GetFightWinner(roundWinnerCount)}");
            DrawShortLine();
            DrawLine();
            RunSpinningAnimation();
        }
        string finalResults = String.Join(",", fightResults);
        Console.WriteLine($"\nFight results:\n{finalResults}");
    }

    private void RunSpinningAnimation()
    {
        string[] spinningSymbols = [ "\\", "|", "/", "-" ];
        int runs = 2;
        for (int i =1; i <= runs; i++)
        {
            for (int j = 0; j < spinningSymbols.Length; j++)
            {
                Console.Write($"\r {spinningSymbols[j % spinningSymbols.Length]}");   
                Thread.Sleep(100);
            }
        }
    }

    private string GetFightWinner(string[] roundWinnerCount)
    {
        int warriorOneRoundWins = 0;
        int warriorTwoRoundWins = 0;
        string roundOneWinner = "";
        string roundTwoWinner = "";
        string roundThreeWinner = "";
        string draw = "Draw";
        for (int i = 0; i < roundWinnerCount.Length; i++)
        {
            if (i == 0)
            {
                roundOneWinner = roundWinnerCount[i];
                warriorOneRoundWins++; 
            }
            else if (i == 1)
            {

                roundTwoWinner = roundWinnerCount[i];
                if (roundTwoWinner != roundOneWinner)
                    warriorTwoRoundWins++;                                
                else                
                    warriorOneRoundWins++;                
            }
            else if (i == 2)
            {
                roundThreeWinner = roundWinnerCount[i];
                if (roundThreeWinner != roundOneWinner)
                    warriorTwoRoundWins++;                
                else                
                    warriorOneRoundWins++;                
            }
        }
        if (warriorOneRoundWins > warriorTwoRoundWins)
            return roundOneWinner;
        else if (warriorOneRoundWins < warriorTwoRoundWins)
            return roundTwoWinner;
        else
            return draw;        
    }

    // Play with IndexOf and Substring to get the result you want
    private string ExtractRoundWinner(string fightReport){

        string fightReportCopy = fightReport;

        int roundWinnerPrefixEndPos = fightReportCopy.IndexOf(":") + 1;

        string roundWinner = fightReportCopy[roundWinnerPrefixEndPos..];
        
        return roundWinner;
    }

    private string GetRoundWinner(string scrollName1, Element scrollElement1, string scrollName2, Element scrollElement2)
    {
        string outcome = "draw";
        
        if (scrollElement1 == Element.Water)
        {
            if (scrollElement2 == Element.Fire)
                outcome = scrollName1;
            else if (scrollElement2 == Element.Ice)
                outcome = scrollName2;
        }
        else if (scrollElement1 == Element.Fire)
        {
            if (scrollElement2 == Element.Ice)
                outcome = scrollName1;
            else if (scrollElement2 == Element.Water)
                outcome = scrollName2;
        }
        else if (scrollElement1 == Element.Ice)
        {
            if (scrollElement2 == Element.Water)
                outcome = scrollName1;
            else if (scrollElement2 == Element.Fire)
                outcome = scrollName2;
        }
        
        return outcome;
    }

    private void PrintWarriorsAndElements(string[] scrollNames, Element[] scrollElements)
    {
        Console.WriteLine($"---Warriors and their elements---");
        Console.WriteLine($"--Initial draft--\n");
        for (int i = 0; i < scrollNames.Length; i++)
        {
            Console.WriteLine($"{scrollNames[i]} - {scrollElements[i].ToString()}");
        }               
        DrawLine();
    }

    private static void DrawLine()
    {
        Console.WriteLine("--------------------------------");
    }

    private static void DrawShortLine()
    {
        Console.WriteLine("--------------");
    }
}