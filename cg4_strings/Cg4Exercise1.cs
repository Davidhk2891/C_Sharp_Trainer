/*
Goal: Demonstrate you understand how to concatenate strings and variables into a single message.
Instructions:
	1.	Create a string variable named firstName with the value "Alice".
	2.	Create a string variable named greeting with the value "Hello".
	3.	Use string concatenation (the + operator) to print this exact message:
    Hello Alice!
*/
public class Cg4Exercise1
{
    public static void Run()
    {
        string firstName = "Alice";
        string greeting = "Hello";
        Console.WriteLine(greeting + " " + firstName + "!"); 
    }
}