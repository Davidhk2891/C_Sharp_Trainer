/*
Goal: Ask the user to enter a number (1-3).
Use a switch statement to print a different message for each option

Rules:
	If the user enters 1 → print “Starting new game…”
	•	If 2 → print “Loading save file…”
	•	If 3 → print “Exiting. Goodbye!”
	•	Otherwise → print “Invalid selection.”
*/
public class Cg12Exercise1
{
    public static void Run()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("FLAPPY ELEMENTAL");
        Console.WriteLine("----------------");

        Console.WriteLine("1 - Start new game\n2 - Load game\n3 - Quit game");
        string? cleanedInput = "";
        string? input = Console.ReadLine();
        cleanedInput= input.ToLower().Trim();

        switch (cleanedInput)
        {
            case "1":
                Console.WriteLine("Starting new game...");
                break;
            case "2":
                Console.WriteLine("Loading save file...");
                break;
            case "3":
                Console.WriteLine("Existing. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid selection");
                break;
        }

    }
}