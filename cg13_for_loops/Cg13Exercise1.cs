/*
Goal:
Write a console app that prints the multiplication table for a number entered by the user

Rules:
	•	Prompt the user:
"Enter a number to generate its multiplication table:"
	•	Use Console.ReadLine() to capture input.
	•	Parse the input into an integer.
	•	Use a for loop to print the table from 1 to 10.
	•	Each line should look like:
5 x 3 = 15
	•	If the user enters an invalid number (not an integer), print:
"Invalid input. Please enter a valid number."

hints:
	•	Use int.TryParse() to handle invalid input gracefully.
	•	Use string interpolation ($"{num} x {i} = {result}") for clean output.
	•	Keep the logic simple and elegant — 3–5 lines inside the loop.

Output:
Enter a number to generate its multiplication table:
7

7 x 1 = 7
7 x 2 = 14
7 x 3 = 21
...
7 x 10 = 70
*/
public class Cg13Exercise1
{
    public static void Run()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Multiplication table generator");
        Console.WriteLine("------------------------------");

        Console.WriteLine("Enter a number to generate its multiplication table:");
        string? userInput = Console.ReadLine();

        int parsedUserInput = 0;

        bool userInputIsParsed = int.TryParse(userInput, out parsedUserInput);
        if (userInputIsParsed)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{parsedUserInput} x {i} = {parsedUserInput * i}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number");
        }
    }
}