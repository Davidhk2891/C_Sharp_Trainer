/*
Goal: Demonstrate you understand declaring variables, reassigning values, and building output dynamically.
Instructions:
	1.	Create variables for:
        •	string playerName = "Bob"
        •	int score = 0
        •	bool isAlive = true
	2.	Print this initial message: 
        Player: Bob, Score: 0, Alive: True
    3.	Update the variables to:
        •	playerName = "Charlie"
        •	score = 150
        •	isAlive = false
	4.	Print the updated message on a new line (same format).

    Use string interpolation for both prints
*/
public class Cg3Exercise3
{
    public static void Run()
    {
        string playerName = "Bob";
        int score = 0;
        bool isAlive = true;

        Console.WriteLine($"Player: {playerName}, Score: {score}, Alive: {isAlive}");

        playerName = "Charlie";
        score = 150;
        isAlive = false;

        Console.WriteLine($"Player: {playerName}, Score: {score}, Alive: {isAlive}");
    }
}