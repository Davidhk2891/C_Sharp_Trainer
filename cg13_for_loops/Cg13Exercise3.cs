/*
Goal:
Write a program that calculates the sum of all even numbers between 1 and 100 (inclusive)

Rules:
	•	Use a for loop that iterates from 1 to 100.
	•	Use the modulus operator (%) to check if a number is even.
	•	If it’s even, add it to a running total.
	•	After the loop ends, print the total sum.

Output:
The sum of all even numbers between 1 and 100 is 2550.
*/

public class Cg13Exercise3
{
    public static void Run()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine("Sum of Even Numbers");
        Console.WriteLine("-------------------");

        int sumOfAllEvenNumbers = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0) sumOfAllEvenNumbers += i;
        }
        Console.WriteLine($"The sum of all even numbers between 1 and 100 is {sumOfAllEvenNumbers}");
    }
}