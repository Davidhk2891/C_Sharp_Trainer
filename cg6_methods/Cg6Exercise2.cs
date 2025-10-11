/*
Goal: Demonstrate you understand how to call a method multiple times and use its return value.
Instructions:
	1.	Create a new Random object called dice.
	2.	Roll the dice three times (generate three random numbers between 1 and 6).
	3.	Print all three results on one line like this:
        Rolls: 3, 5, 2
    👉 Use one Console.WriteLine and interpolation.
*/
public class Cg6Exercise2
{
    public static void Run()
    {
        Random dice = new Random();
        int lowerBound = 1;
        int upperBound = 7;
        int randomNum1 = dice.Next(lowerBound, upperBound);
        int randomNum2 = dice.Next(lowerBound, upperBound);
        int randomNum3 = dice.Next(lowerBound, upperBound);

        Console.WriteLine($"Rolls: {randomNum1}, {randomNum2}, {randomNum3}");
    }
}