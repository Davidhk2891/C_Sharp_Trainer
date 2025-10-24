/*
Goal: Create a console app that asks for a secret code and checks if it's correct

Rules:
The user must type a secret code.
	•	The correct code is "galaxy42".
	•	You must use .ToLower() and .Trim() to normalize user input before comparing.
	•	If the input matches (after normalization), print:
"Welcome to the Galactic Network."
	•	If it’s empty, print:
"You must enter a code."
	•	Otherwise, print:
"Access denied."

Hints:
- .ToLower() converts everything to lowercase, so "GaLAXY42" becomes "galaxy42"
- .Trim() removes leading and trailing spaces "  galaxy42 " becomes "galaxy42"
*/
public class Cg11Exercise2
{
    public static void Run()
    {
        Console.WriteLine("Enter password: ");
        string? password = Console.ReadLine();
        string? fixedPassword = password.ToLower().Trim();

        bool correctCode = fixedPassword == "galaxy42";
        bool emptyCode = string.IsNullOrEmpty(fixedPassword);

        // Console.WriteLine($" Password type: {fixedPassword}");

        if (emptyCode)
        {
            Console.WriteLine("You must enter a code.");   
        }
        else if (correctCode)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Welcome to the Galaxy network.");
            Console.WriteLine("------------------------------");   
        }
        else
        {
            Console.WriteLine("Access denied.");
        }
        
    }
}