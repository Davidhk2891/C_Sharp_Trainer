/*
Goal:
Simulate a "brute force" password cracker using a while loop

Requirements:
	1.	The program picks a secret password (you can hardcode it, like "xyz").
	2.	It uses a while loop to guess random three-letter passwords until it matches the secret.
	3.	Use characters from 'a' to 'z' only.
	4.	Each attempt prints something like:
        Attempt 1: Trying "aef"...
        Attempt 2: Trying "xyz"...
    5. When the correct password is found, print:
        Password cracked! The password was "xyz"
    6. Show how many attempts it took

Hint:
You’ll want to use nested loops or string building logic to generate guesses —
but since you haven’t learned methods yet, it’s okay to simulate this with Random for now.
Focus on the while condition and the stop condition when the guess matches the password.

EXERCISE RUNS BUT NEEDS FIXING.
*/
public class Cg14Exercise3
{
    public static void Run()
    {

        Console.WriteLine("-----------------");
        Console.WriteLine("Password cracker!");
        Console.WriteLine("-----------------");

        string password = "grt";
        string[] alphabet = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
        string[] guessArr = new string[3];
        string guess;
        int lettersCaught = 0;
        int previousPreviousPosition = -1;
        int previousPosition = -1;
        int newPosition;
        int attempt = 0;
        Random rand = new();

        do
        {
            while (lettersCaught <= 2)
            {
                // catch a letter and avoid repeated letter
                do
                {
                    newPosition = rand.Next(0, alphabet.Length);
                } while (newPosition == previousPreviousPosition && newPosition == previousPosition);

                if (lettersCaught == 0)
                    previousPreviousPosition = newPosition;
                else if (lettersCaught == 1)
                    previousPosition = newPosition;

                guessArr[lettersCaught] = alphabet[newPosition];
                lettersCaught++;
            }
            guess = string.Join("", guessArr);
            
            lettersCaught = 0;
            attempt++;

            Console.WriteLine($"attempt: {attempt}: Trying {guess}");

        } while (guess != password);
        Console.WriteLine($"Password cracked! The password was {guess}");
    }
}