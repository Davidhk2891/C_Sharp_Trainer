/*
- The Elemental Codex

Premise:
A scroll arrives containing a comma-separated list of warrior names and their elements.
Your job is to parse the scroll, assign elements, run 3 quick duels, and print a summary

Setup:
Warrior data arrives as a single string: "Ashveil:Fire,Dreadmaw:Water,The Hollow:Ice,Seraphon:Fire"
Parse it into names and elements using Split()
Run 3 duels: 0v1, 1v2, 2v3

Rules:
 - Use Split(',') to separate warriors, then Split(':') to separate name from element
 - Use your Element enum and GetWinner() from memory
 - Show a spinner animayion (|, /, --, \) for 1 second before revealing each fight result
 - Use a ternary to format the result line: win or draw, one line
 - Use modulus to print a divider after every 2nd duel
 - Print a final summary of results
*/

public class DailyEx010TheElementalCodex
{
    string rawDataScroll = "Ashveil:Fire,Dreadmaw:Water,The Hollow:Ice,Seraphon:Fire";
    private Random rand = new();

    enum Element
    {
        Fire,
        Water,
        Ice,
        None
    }
    public void RunApp()
    {
        /* 
        One step at a time

        1) Declare fields -- DONE
        2) Split raw data and assign names to names array and elements to elements array -- DONE
        3) Declare Element enum -- DONE
        4) Write GetWinner() -- DONE
        5) Run 3 matches -- DONE

        */

        Console.Clear();
        DecodeScroll();
    }

    private void DecodeScroll()
    {
        string[] warriorsData = rawDataScroll.Split(",");
        string[] warriorsNames = new string[warriorsData.Length];
        string[] warriorsElements = new string[warriorsData.Length];

        DrawLine();
        Console.WriteLine("...Codex...");
        DrawLine();
        for (int i = 0; i < warriorsData.Length; i++)
        {
            Console.WriteLine($"{warriorsData[i]}");

            int startPosition = 0;
            int colonPosition = warriorsData[i].IndexOf(':');
            int warriorLength = colonPosition - startPosition;

            warriorsNames[i] = warriorsData[i].Substring(startPosition, warriorLength);
            warriorsElements[i] = warriorsData[i][(colonPosition + 1)..];
        }
        DrawLine();
        DrawLineWithSpace();

        RunMatches(warriorsNames, warriorsElements);
    }

    private void RunMatches(string[] warriorNames, string[] warriorElements)
    {
        for (int i = 0; i < warriorNames.Length - 1; i++)
        {
            DrawLine();
            Console.WriteLine($"> {warriorNames[i]} vs {warriorNames[i + 1]} <");
            Console.WriteLine($"{warriorNames[i]} uses {warriorElements[i]}");
            Console.WriteLine($"{warriorNames[i + 1]} uses {warriorElements[i + 1]}");
            string result = GetWinner(warriorNames[i], warriorElements[i], warriorNames[i + 1], warriorElements[i + 1]);
            Console.WriteLine(result == "Draw!" ? "Draw!" : $"{result} wins!");
            DrawLineWithSpace();
            if ((i + 1) % 2 == 0) DrawLine();
            AwaitNextMatch();
        }
    }

    private Element ParseMobElement(string mobElement)
    {
        Element mobParsedElement;
        switch (mobElement)
        {
            case "Fire":
                mobParsedElement = Element.Fire;
                break;
            case "Water":
                mobParsedElement = Element.Water;
                break;
            case "Ice":
                mobParsedElement = Element.Ice;
                break;
            default:
                mobParsedElement = Element.None;
                break;
        }
        return mobParsedElement;
    }

    private string GetWinner(string mob1Name, string mob1Element, string mob2Name, string mob2Element)
    {
        Element mob1ParsedElement = ParseMobElement(mob1Element);
        Element mob2ParsedElement = ParseMobElement(mob2Element);
        string draw = "Draw!";
        string mobWinner = draw;

        if (mob1ParsedElement == Element.Fire)
        {
            if (mob2ParsedElement == Element.Ice)
                mobWinner = mob1Name;
            else if (mob2ParsedElement == Element.Water)            
                mobWinner = mob2Name;                    
        }
        else if (mob1ParsedElement == Element.Water)
        {
            if (mob2ParsedElement == Element.Fire)            
                mobWinner = mob1Name;
            else if (mob2ParsedElement == Element.Ice)
                mobWinner = mob2Name;
        }
        else if (mob1ParsedElement == Element.Ice)
        {
            if (mob2ParsedElement == Element.Water)
                mobWinner = mob1Name;
            else if (mob2ParsedElement == Element.Fire)
                mobWinner = mob2Name;
        }
        
        return mobWinner;
    }

    // Utilities

    private static void AwaitNextMatch()
    {
        string[] spinningSymbols = ["\\", "|", "/", "-"];
        int spins = 4;

        for (int i = 1; i <= spins; i++)
        {
            for (int j = 0; j < spinningSymbols.Length; j++)
            {
                Console.Write($"\r {spinningSymbols[j % spinningSymbols.Length]}");
                Thread.Sleep(100);
            }   
        }
        Console.Write($"\r {new String(' ', Console.BufferWidth)}");
    }
    private static void DrawLine()
    {
        Console.WriteLine("------------------");
    }

    private static void DrawLineWithSpace()
    {
        Console.WriteLine("------------------\n");
    }
}