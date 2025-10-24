/*
Goal: Build a simple but dynamic console app that simulates the following:
    - flipping a coin multiple times
    - tracks results
    - displays a summary
You'll use Random, booleans, loops and conditionals to handle outcomes and reporting

Requirements: 
    1. The app should:
        - Flip a virtual coin 10 times (you can use a loop)
        - Randomly assign each result as "Heads" or "Tails"
        - Keep count of how many times Heads and Tails appear
        - At the end, print a summary report showing total flips and which side won more often (or if it's a tie)
    2. You must use:
        - The Random class for randomization
        - if / else statements or boolean expressions to track outcomes
        - Variables to store counts and results
        - String interpolation for clean console output

Summary format:
-------------------
COIN FLIPPER v2.0
-------------------

Flip 1: Heads
Flip 2: Tails
Flip 3: Heads
...
Flip 10: Tails

-------------------
RESULTS
-------------------
Heads: 6
Tails: 4
Outcome: Heads wins!
-------------------
Press any key to continue...
*/
public class CoinFlipper
{
    public static void RunApp()
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("COIN FLIPPER V2.0");
        Console.WriteLine("-----------------");

        Random flip = new Random();

        int result = 0;
        string[] listOfResults = new string[10];

        int headsCounter = 0;
        int tailsCounter = 0;

        for (int i = 0; i < listOfResults.Length; i++)
        {
            result = flip.Next(0, 2);
            if (result == 0)
            {
                listOfResults[i] = "Heads";
                headsCounter++;
            }
            else
            {
                listOfResults[i] = "Tails";
                tailsCounter++;
            }
            Console.WriteLine($"Flip {i + 1}: {listOfResults[i]}");
        }

        Console.WriteLine("----------");
        Console.WriteLine("RESULTS");
        Console.WriteLine("----------");
        Console.WriteLine($"Heads: {headsCounter}");
        Console.WriteLine($"Tails: {tailsCounter}");

        // Outcome
        string outcome = headsCounter == tailsCounter ? "It's a tie" : $"{(headsCounter > tailsCounter ? "Heads" : "Tails")} wins!";
        Console.WriteLine(outcome);

        Console.WriteLine("-----------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}