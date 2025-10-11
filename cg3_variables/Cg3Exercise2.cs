/*
Goal: Demonstrate you understand how to declare multiple variables of different types, assign values, and print them together in a formatted message.
Instructions:
	1.	Declare variables for:
        •	string name
        •	int age
        •	decimal balance
	2.	Assign them the values "Alice", 28, and 5023.75.
	3.	Print a single message to the console that looks like this (one line):
    -- Name: Alice, Age: 28, Balance: 5023.75
    4. Use string interpolation instead of concatenation
*/
public class Cg3Exercise2
{
    public static void Run()
    {
        string name = "Alice";
        int age = 28;
        decimal balance = 5023.75m;
        Console.WriteLine($"Name: {name}, Age: {age}, Balance: {balance}");
    }
}