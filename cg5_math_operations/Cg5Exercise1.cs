/*
Goal: Demonstrate you understand basic math operators (+, -, *, /) with integers.
Instructions:
	1.	Create two int variables: a = 10 and b = 3.
	2.	Calculate their sum, difference, product, and quotient into separate variables.
	3.	Print them in this format (each on its own line):
    Sum: 13
    Difference: 7
    Product: 30
    Quotient: 3
*/
public class Cg5Exercise1
{
    public static void Run()
    {
        int a = 10;
        int b = 3;
        int sum = a + b;
        int diff = a - b;
        int product = a * b;
        int quotient = a / b;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {diff}");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Quotient: {quotient}");
    }
}