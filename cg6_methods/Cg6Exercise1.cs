/*
Goal: Demonstrate you understand how to call a method from the .NET Class Library.
Instructions:
	1.	Create a new instance of the Random class called dice.
	2.	Use it to generate a random number between 1 and 6 (inclusive).
	3.	Print the result like this:
        Dice roll: 4
    👉 Use interpolation in the Console.WriteLine.
    👉 Don’t overthink it — one object, one method call.
*/
public class Cg6Exercise1
{
    public static void Run()
    {
        Random dice = new Random();
        int randomNum = dice.Next(1, 7);
        Console.WriteLine($"Dice roll: {randomNum}");
    }
}