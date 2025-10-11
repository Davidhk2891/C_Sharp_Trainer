/*
Goal: Demonstrate you understand how to use % to check divisibility by multiple numbers.
Instructions:
	1.	Create an int number = 30;
	2.	Print three separate lines:
        •	Whether it’s divisible by 3.
        •	Whether it’s divisible by 5.
        •	Whether it’s divisible by both 3 and 5.
	3.	The output should look exactly like this:
    Divisible by 3? True
    Divisible by 5? True
    Divisible by 3 and 5? True
    👉 Use boolean expressions inside the interpolation, no hardcoding True/False.
*/
public class Cg5Exercise4
{
    public static void Run()
    {
        bool isDivisibleBy3 = 30 % 3 == 0;
        bool isDivisibleBy5 = 30 % 5 == 0;
        bool isDivisibleBy3And5 = (30 % 3 == 0) && (30 % 5 == 0);

        Console.WriteLine($"Divisible by 3? {isDivisibleBy3}");
        Console.WriteLine($"Divisible by 5? {isDivisibleBy5}");
        Console.WriteLine($"Divisible by 3 and 5? {isDivisibleBy3And5}");
    }
}