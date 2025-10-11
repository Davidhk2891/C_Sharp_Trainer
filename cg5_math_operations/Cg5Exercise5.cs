/*
Goal: Demonstrate you understand how to use % to check divisibility for multiple hardcoded values.
Instructions:
	1.	Create three int variables: a = 12, b = 19, c = 20.
	2.	For each variable, print whether it’s divisible by 2 (even) in this format:
        12 is even? True
        19 is even? False
        20 is even? True
*/
public class Cg5Exercise5
{
    public static void Run()
    {
        int a = 12;
        int b = 19;
        int c = 20;
        Console.WriteLine($"{a} is even? {a % 2 == 0}");
        Console.WriteLine($"{b} is even? {b % 2 == 0}");
        Console.WriteLine($"{c} is even? {c % 2 == 0}");
    }
}