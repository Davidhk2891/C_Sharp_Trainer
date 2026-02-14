/*
Goal:
Revisit logic, loops, and arrays. Simulate simple elemental matchups.

Rules:
	1.	Create a program that asks the player to pick an element: "Water", "Fire", or "Ice".
	2.	The computer randomly picks one of the same three elements.
	3.	Print both choices.
	4.	Determine who wins based on these rules:
	    •	Water beats Fire
	    •	Fire beats Ice
	    •	Ice beats Water
	    •	Same element = Draw
	5.	Ask if the player wants to play again. If they type "y", repeat; otherwise, end the 
    program with "Thanks for playing!".
*/
public class DailyEx002ElementCrashRefresher
{
    public static void RunApp()
    {
        // Simulate elemental matchups

        // 1. Define rules
        string? userInput;
        string computerInput;
        bool playerWins = false;
        bool computerWins = false;
        bool draw = false;
        string resultsMessage;

        Random random = new();
        int choosenNumber = random.Next(1, 4);

        // User input
        do
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Select an element:\n\nWater\nFire\nIce");
            Console.WriteLine("--------------------------------------");
            userInput = Console.ReadLine()?.ToLower().Trim();
        
            if (userInput == "")
                Console.WriteLine("\nYou must enter an element\n");
            else if (userInput != "fire" && userInput != "water" && userInput != "ice")
                Console.WriteLine("\nInvalid input. you must enter an element\n");

        } while (userInput == "" || (userInput != "fire" && userInput != "water" && userInput != "ice"));

        // Computer input
        switch (choosenNumber)
        {
            case 1:
                computerInput = "fire";
                break;
            case 2:
                computerInput = "water";
                break;
            case 3:
                computerInput = "ice";
                break;
            default:
                computerInput = "none";
                break;
        }

        Console.WriteLine($"User input: {userInput} - Computer input: {computerInput}");

        switch (userInput)
        {
            case "water":
                playerWins = computerInput == "fire";
                computerWins = computerInput == "ice";
                draw = computerInput == "water";
                break;
            case "fire":
                playerWins = computerInput == "ice";
                computerWins = computerInput == "water";
                draw = computerInput == "fire";
                break;
            case "ice":
                playerWins = computerInput == "water";
                computerWins = computerInput == "fire";
                draw = computerInput == "ice";
                break;
        }

        if (playerWins) resultsMessage = "Player wins";
        else if (computerWins) resultsMessage = "Computer wins";
        else if (draw) resultsMessage = "Draw";
        else resultsMessage = "";

        Console.WriteLine($"{resultsMessage}. Good bye");
    }
}