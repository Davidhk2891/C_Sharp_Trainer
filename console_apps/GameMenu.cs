/*
Goal: 
Build a simple main menu system for your future game that lets players navigate and choose actions through text input

Requirements:
    1. Display a title screen
    -------------------------
    FLAPPY ELEMENTAL V2.0
    -------------------------
    1 - Start new game
    2 - Element Codex
    3 - Quit
    -------------------------

    2. User input
    •	Ask the player to type an option (1, 2, or 3).
	•	Use Console.ReadLine() to get input.
	•	Trim spaces and handle case insensitivity (e.g. “ 1 ” should still work).

    3. Switch logic
    •	If 1 → print "Starting new game...".
	•	If 2 → enter a second menu (the Element Codex) where the user can type an element (Water, Fire, Ice) to get its description.
	•	If 3 → print "Exiting game... Goodbye!" and end the program.
	•	Any other input → print "Invalid option".

    4.	Element Codex Submenu
	•	Should loop until the user types q to return to the main menu.
	•	Each element prints:
        •	Water → “Flowing and adaptive. Strong against Fire.”
        •	Fire → “Fierce and consuming. Strong against Ice.”
        •	Ice → “Cold and relentless. Strong against Water.”
	•	Anything else → “Unknown element.”

    5. Bonus challenge
    Add a short "Press any key to return..." pause after Codex or New Game options. Optional but makes it feel more game-y
*/
public class GameMenu
{
    public static void RunApp()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("FLAPPY ELEMENTAL V2.0");
        Console.WriteLine("---------------------");
        Console.WriteLine("1 - Start new game\n2 - Load game\n3 - Element Codex\n4 - Quit");
        Console.WriteLine("---------------------");

        string? menuInput = Console.ReadLine()?.Trim();

        switch (menuInput){
            case "1":
                Console.WriteLine("Starting new game...");
                break;
            case "2":
                Console.WriteLine("Select game slot:");
                Console.WriteLine("1 - Empty");
                Console.WriteLine("2 - Empty");
                Console.WriteLine("3 - Empty");
                string? gameSlotInput = Console.ReadLine();
                switch (gameSlotInput)
                {
                    case "1":
                    case "2":
                    case "3":
                        Console.WriteLine("Slot is empty");
                        break;
                    default:
                        break;
                }
                break;
            case "3":
                Console.WriteLine("-------------");
                Console.WriteLine("Element Codex");
                Console.WriteLine("-------------");
                Console.WriteLine("1 - Water\n2 - Fire\n3 - Ice");
                string? codexInput = Console.ReadLine()?.Trim().ToLower();
                switch (codexInput)
                {                    
                    case "1":
                        Console.WriteLine("Flowing adn adaptive. Strong against Fire.");
                        break;
                    case "2":
                        Console.WriteLine("Fierce and consuming. Strong against Ice");
                        break;
                    case "3":
                        Console.WriteLine("Cold and relentless. Strong against Water");
                        break;
                    default:
                        Console.WriteLine("Unkown element");
                        break;
                }
                break;
            case "4":
                Console.WriteLine("Exiting game. Goodbye.");
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }
}