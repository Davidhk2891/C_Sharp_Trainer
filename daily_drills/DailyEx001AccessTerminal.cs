/*
Goal: 
    - Practice string handling and conditionals

Rules:
    1.	Ask the user to enter a secret passcode.
	2.	If it’s "open-sesame", print: Access granted. Welcome, Agent.
	3.	If the user just presses Enter (empty input), print: You must enter a passcode.
	4.	Otherwise, print: Access denied.
	5.	Ignore case and extra spaces (hint: Trim() and ToLower()).
*/

public class DailyEx001AccessTerminal
{
    public static void RunApp()
    {
        // 1. Ask the user to enter a secret passcode
        // 2. If it’s "open-sesame", print: Access granted. Welcome, Agent.
        // 3. If the user just presses Enter (empty input), print: You must enter a passcode.
	    // 4. Otherwise, print: Access denied.
	    // 5. Ignore case and extra spaces (hint: Trim() and ToLower()).
        // How to print new line
        Console.WriteLine("Hello David. You are back from the graveyard it seems");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Excercise 1 - Access Terminal");
        Console.WriteLine("-----------------------------------------------------"); 
        Console.WriteLine("\n");
        Console.WriteLine("Please enter the passcode");
        // How to read user input
        string? userInput = Console.ReadLine()?.ToLower().Trim();
        // While user input is empty OR user input is not "open-sesame"
        //
        while (userInput == "" || userInput != "open-sesame")
        {
            if (userInput == "")
            {
                Console.WriteLine("You must enter a passcode.");
            } 
            else
            {
                Console.WriteLine("Access denied");   
            }
            userInput = Console.ReadLine()?.ToLower().Trim();
        }
        Console.WriteLine($"You entered: {userInput}");
        Console.WriteLine("Access granted. Welcome, Agent");
    }
}