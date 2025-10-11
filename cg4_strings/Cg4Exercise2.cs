/*
Goal: Demonstrate you understand how to use string interpolation to build a message.
Instructions:
	1.	Create the same two variables as before:
	•	string firstName = "Alice";
	•	string greeting = "Hello";
	2.	Use string interpolation ($"...") to print this exact message:
    Hello Alice!
*/
public class Cg4Exercise2
{
    public static void Run()
    {
        string firstName = "Alice";
        string greeting = "Hello";
        Console.WriteLine($"{greeting} {firstName}!");
    }
}