/*
Goal: Demonstrate you can use nested if statements combined with Boolean operators to control flow

Scenario: You're writing a small system that checks whether a user can enter a concert

Rules:
	•	Must be 18+
	•	Must have a ticket
	•	If both → "Welcome to the show!"
	•	If 18+ but no ticket → "You need a ticket to enter."
	•	If under 18 → "You must be 18 or older to enter."
*/
public class Cg7Exercise3
{
    public static void Run()
    {
        bool clientOver18 = true;
        bool hasTicket = false;

        if (clientOver18)
        {
            if (hasTicket)
            {
                Console.WriteLine("Welcome to the show!");
            }
            else
            {
                Console.WriteLine("You need a ticket to enter.");
            }
        }
        else
        {
            Console.WriteLine("You must be 18 or older to enter.");
        }
    }
}