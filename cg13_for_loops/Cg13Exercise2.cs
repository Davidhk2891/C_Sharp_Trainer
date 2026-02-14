/*
Goal:
Create a countdown timer from 10 to 1

Rules:
	•	Use a for loop that counts downward (from 10 to 1).
	•	Print each number on a new line.
	•	After the loop ends, print "Blast off!".
	•	(Optional) Add a short pause between each number using Thread.Sleep(500) — half a second.

Output:
10
9
8
7
6
5
4
3
2
1
*/
public class Cg13Exercise2
{
    public static void Run()
    {
        Console.WriteLine("---------------");
        Console.WriteLine("Countdown timer");
        Console.WriteLine("---------------");

        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }
}