/*
Goal: 
You're building a Flappy Elemental codex.
A mini database where the player can type an element's name and get info about it

Specs:
Ask the user to input an element name (Water, Fire, or Ice).
	•	Use a switch to print each element’s description:
	•	Water: “Flowing and adaptive. Strong against Fire.”
	•	Fire: “Fierce and consuming. Strong against Ice.”
	•	Ice: “Cold and relentless. Strong against Water.”
	•	If the input doesn’t match any element → print "Unknown element."

Bonus:
Handle case insensitivity and trim extra spaces, like you did before.
*/
public class Cg12Exercise2
{
    public static void Run()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("FLAPPY ELEMENTAL CODEX");
        Console.WriteLine("----------------------");


        Console.WriteLine("Type element for info (Water, Fire, Ice). Q to quit game");
        string? input = Console.ReadLine()?.Trim().ToLower();

        switch (input)
        {   
            case "water":
                Console.WriteLine("Flowing and adaptive. String against Fire");
                break;
            case "fire":
                Console.WriteLine("Fierce and consuming. Strong against Ice");
                break;
            case "ice":
                Console.WriteLine("Cold and relentless. Strong against Water");
                break;
            case "q":
                Console.WriteLine("Exiting game");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }   
    }
}