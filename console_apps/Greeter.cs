/*
Goal: Demonstrate you can combine variables, literals, and Console.Write/WriteLine to build a formatted message.
Instructions:
	1.	Create three variables:
	•	string firstName = "Bob";
	•	int totalMessages = 3;
	•	double temperature = 34.4;
	2.	Print this exact output (punctuation and spacing must match):
        Hello, Bob! You have 3 messages in your inbox. The temperature is 34.4 celsius.
    👉 Use multiple Console.Write/WriteLine calls (not interpolation).
*/
public class Greeter
{
    public static void RunApp()
    {
        string firstName = "Bob";
        int totalMessages = 3;
        double temperature = 34.4;
        Console.Write("Hello, " + firstName + "! ");
        Console.Write("You have " + totalMessages + " messages in your inbox. ");
        Console.Write("The temperature is " + temperature + " celsius.");
    }
}
