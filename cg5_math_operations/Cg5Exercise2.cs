/*
Goal: Demonstrate you understand how to perform division with decimals and avoid truncation.
Instructions:
	1.	Create two int variables: x = 7 and y = 5.
	2.	Divide x / y and store the result in a decimal variable using casting.
	3.	Print the result with this exact message:
    Quotient: 1.4
*/
public class Cg5Exercise2
{
    public static void Run()
    {
        int x = 7;
        int y = 5;
        decimal quotient = (decimal)x / y;
        Console.WriteLine($"Quotient: {quotient}");

    }
}