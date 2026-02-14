/*
Goal:
Demonstrate you understand how a do-while loop ensures at least one iteration before validating success conditions.

Instructions:
Create a console app that simulates repeatedly trying to connect to a game server until a random "connection success" occurs.

Requirements:
1.	Use a do-while loop to keep trying until a connection succeeds.
	2.	Use Random.Next(1, 6) to simulate connection attempts (values 1–5).
	•	If the number is 5, the connection is successful.
	•	Otherwise, print “Connection failed. Retrying…”
	3.	Count the number of attempts.
	4.	When successful, print:
"Connected to server after X attempts!"

Output:
Attempt 1: Connection failed. Retrying...
Attempt 2: Connection failed. Retrying...
Attempt 3: Connected to server after 3 attempts!
*/
public class Cg14Exercise2
{
    public static void Run()
    {
        Console.WriteLine("---------------");
        Console.WriteLine("WARRIORS ONLINE");
        Console.WriteLine("---------------");
        int connectionSuccessful = 5;
        int connectionAttempt;
        int attempt = 0;
        Random random = new Random();
        do
        {
            Thread.Sleep(1000);
            attempt++;
            connectionAttempt = random.Next(1, 6);
            if (connectionAttempt != connectionSuccessful) Console.WriteLine($"Attempt {attempt}: Connection failed. Retrying");
            else continue;
        } while (connectionAttempt != connectionSuccessful);

        Console.WriteLine($"Attempt {attempt}: Connected to server after {attempt} attempts!");
    }
}