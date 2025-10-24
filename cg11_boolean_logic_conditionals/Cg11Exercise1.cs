/*
Goal: Write a console app that checks if a user can access a secret area

Rules:
    - The user has to type a password
    - If the password is "opensesame", print
    "Access granted. Welcome, adventurer"

    - If the password is empty, print
    "You must enter a password"

    - Otherwise print
    "Access denied"

Hint:
    - Use Console.ReadLine() to get user input.
    - Use string.IsNullOrEmpty(password) to check if the string is empty or null
*/

public class Cg11Exercise1
{
    public static void Run()
    {

        Console.WriteLine("Enter password");
        string? password = Console.ReadLine();

        bool accessGranted = password == "opensesame";
        bool emptyPassword = string.IsNullOrEmpty(password);

        if (emptyPassword)
            Console.WriteLine("You must enter a password");
        else if (accessGranted)
            Console.WriteLine("Access granted. Welcome, adventurer");
        else
            Console.WriteLine("Access denied");
    }
}