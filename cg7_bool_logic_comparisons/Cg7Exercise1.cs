/*
Goal: Demonstrate you understand Boolean expressions and comparison operators in C#.
You'll write expressions that evaluate to true or false based on given variables and print the results

Create three integer variables:
a = 5, b = 10, and c = 5.

Then, print the result of these Boolean expressions:
	1.	Is a equal to b?
	2.	Is a less than b?
	3.	Is a equal to c?
	4.	Is b greater than or equal to c?

You should display the results in a readable way — for example:
"a == b: False"
*/
public class Cg7Exercise1
{
    public static void Run()
    {
        int a = 5, b = 10, c = 5;
        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a < b: {a < b}");
        Console.WriteLine($"a == c: {a == c}");
        Console.WriteLine($"b >= c: {b >= c}");
    }
}