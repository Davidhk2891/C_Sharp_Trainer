/*
CG3 – Exercise 1

Goal: Demonstrate you understand how to declare, assign, reassign, and print variables.

Instructions:
	1.	Declare a variable to hold a person’s name (string).
	2.	Assign it the value "Bob".
	3.	Print it to the console.
	4.	Reassign the same variable to "Alice".
	5.	Print it again.

👉 Only use one variable for the name.
*/
public class Cg3Exercise1
{
    public static void run()
    {
        string name = "Bob";
        Console.WriteLine(name);
        name = "Alice";
        Console.WriteLine(name);
    }
}