/*
Goal:
Write a program that keeps asking the user to enter a number between 1 and 10 until they actually do

Rules:
	•	Use a do-while loop.
	•	Inside the loop:
	•	Prompt the user for a number.
	•	Parse it with int.TryParse().
	•	If it’s not between 1 and 10, tell them and repeat.
	•	Once they give a valid number, print a confirmation and end the program.

Output:
Enter a number between 1 and 10:
15
Invalid number, try again.
3
You entered a valid number: 3
*/
public class Cg14Exercise1
{
    public static void Run()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Repeat Until Valid Input");
        Console.WriteLine("------------------------");

        int parsedInput;
        bool isWithinRange;
        bool userEnteredInput; 

        Console.WriteLine("Enter a number between 1 and 10");
        do
        {
            userEnteredInput = int.TryParse(Console.ReadLine(), out parsedInput);
            isWithinRange = parsedInput >= 1 && parsedInput <= 10;
            if (!isWithinRange)
                Console.WriteLine("Invalid number, try again.");
            else
                continue;
        } while (!userEnteredInput || !isWithinRange);
        Console.WriteLine($"You entered a valid number: {parsedInput}");
    }
}