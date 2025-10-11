/*
Goal: Demonstrate you understand how to combine multiple Boolean expressions using && (AND) || (OR)

Instructions:
Create three int variables:
x = 7, y = 3, z = 5.

Then print the result of the following conditions:
	1.	Is x greater than both y and z?
	2.	Is z between y and x (inclusive)?
	3.	Is x less than y or equal to z?

Use string interpolation to clearly display each condition and its Boolean result, like this:
"x > y && x > z: True"
*/
public class Cg7Exercise2
{
    public static void Run()
    {
        int x = 7, y = 3, z = 5;

        // 1. Is x greater than both y and z
        Console.WriteLine($"x > y && x > z: {x > y && x > z}");

        // 2. Is z between y and x (inclusive)
        Console.WriteLine($"z > y && z < x: {z > y && z < x}");

        // 3. Is x less than y or equal to z
        Console.WriteLine($"x < y || x == z: {x < y || x == z}");
    }
}