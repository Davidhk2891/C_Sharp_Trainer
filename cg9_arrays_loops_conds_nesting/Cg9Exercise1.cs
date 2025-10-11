/*
Element clash table console app

Project overview:
I run a fantasy card game where players collect elemental cards — Water, Fire, and Ice.
Each element has specific strengths and weaknesses, and I want a simple console program that displays how each element interacts with the others.
Basically, I should be able to run the program and clearly see who each element beats, loses to, and draws with

What the client needs:
Create a console app that prints a table of matchups between Water, Fire and Ice.
For every element, show how it performs against each of the three (including itself)

Rules:
- Water defeats Fire
- Fire defeats Ice
- Ice defeats water
- When an element fights itself, the result is always Draw

UI:
------------------------
ELEMENT CLASH TABLE
------------------------

Water outcomes:
    vs Water: Draw
    vs Fire: Win
    vs Ice: Lose

Fire outcomes:
    vs Water: Lose
    vs Fire: Draw
    vs Ice: Win

Ice outcomes:
    vs Water: Win
    vs Fire: Lose
    vs Ice: Draw

------------------------
Press any key to continue...

Deliverables:
- A single .cs console app file that, when run, prints the table exactly as shown.
- The app should be dynamic (no manual print lines for each case).
    Meaning, if we add a new element later, it should automatically appear in the table
    This matters because we'll use the same base logic for future combat simulations in the game.
    So it needs to be clean, accurate and easy to expand

Remember, break down the big problem into smaller, manageable problems
*/
public class Cg9Exercise1
{
    public static void Run()
    {

        // Declare data
        string[] elements = ["Water", "Fire", "Ice"];
        string[] playerElements = elements;
        string[] obstacleElements = elements;

        // Print app headers
        Console.WriteLine("------------------------");
        Console.WriteLine("ELEMENT CLASH TABLE V1.0");
        Console.WriteLine("------------------------");

        Console.WriteLine("------------------------\n");
        foreach (string playerElement in playerElements)
        {
            string currentPlayerElement = playerElement;

            Console.WriteLine($"{playerElement} outcomes:");

            foreach (string obstacleElement in obstacleElements)
            {
                if (playerElement == "Water")
                {
                    if (obstacleElement == "Water")
                        Console.WriteLine("\tvs Water:\tDraw");

                    else if (obstacleElement == "Fire")
                        Console.WriteLine("\tvs Fire:\tWin");

                    else if (obstacleElement == "Ice")
                        Console.WriteLine("\tvs Ice:\t\tLose");

                    else
                        continue;
                }
                else if (playerElement == "Fire")
                {
                    if (obstacleElement == "Water")
                        Console.WriteLine("\tvs Water:\tLose");

                    else if (obstacleElement == "Fire")
                        Console.WriteLine("\tvs Fire:\tDraw");

                    else if (obstacleElement == "Ice")
                        Console.WriteLine("\tvs Ice:\t\tWin");

                    else
                        continue;
                }
                else if (playerElement == "Ice")
                {
                    if (obstacleElement == "Water")
                        Console.WriteLine("\tvs Water:\tWin");

                    else if (obstacleElement == "Fire")
                        Console.WriteLine("\tvs Fire:\tLose");

                    else if (obstacleElement == "Ice")
                        Console.WriteLine("\tvs Ice:\t\tDraw");

                    else
                        continue;
                }
                else
                    continue;
            }
            Console.WriteLine("\n");   
        }

        Console.WriteLine("------------------------");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();

    }
}