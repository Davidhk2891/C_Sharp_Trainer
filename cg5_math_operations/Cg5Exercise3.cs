/*
Goal: Demonstrate you understand how to use % to check divisibility.
Instructions:
	1.	Create an int number = 15;
	2.	Use modulus to check if number is divisible by 2.
	3.	Print this exact message:
    15 is even? False
*/
public class Cg5Exercise3
{
    public static void Run()
    {
        int number = 15;
        bool isEven = number % 2 == 0;
        Console.WriteLine($"15 is even? {isEven}");
    }
}