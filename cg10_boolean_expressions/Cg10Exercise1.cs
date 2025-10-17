/*
Goal: Create a few variables and compare their values using different relational operators.
You'll print the results to confirm if each comparison is true or false

Instructions: 
1. Create three integer variables: age, minAge, and maxAge
2. Compare them using these operators:
    •	> (greater than)
	•	< (less than)
	•	>= (greater than or equal to)
	•	<= (less than or equal to)
	•	== (equal to)
	•	!= (not equal to)
3. Store each comparison result in a boolean variable
4. Print the results clearly, like: Age is greater than minAge: True.
*/
public class Cg10Exercise1
{
    public static void Run()
    {
        int age = 33;
        int minAge = 18;
        int maxAge = 120;

        // age and minAge
        bool isAgeGreaterThanMinAge = age > minAge;
        bool isAgeLessThanMinAge = age < minAge;
        bool isAgeGreaterOrEqualToMinAge = age >= minAge;
        bool isAgeLessOrEqualToMinAge = age <= minAge;
        bool isAgeEqualToMinAge = age == minAge;
        bool isAgeNotEqualToMinAge = age != minAge;

        // age and maxAge
        bool isAgeGreaterThanMaxAge = age > maxAge;
        bool isAgeLessThanMaxAge = age < maxAge;
        bool isAgeGreaterOrEqualToMaxAge = age >= maxAge;
        bool isAgeLessOrEqualToMaxAge = age <= maxAge;
        bool isAgeEqualToMaxAge = age == maxAge;
        bool isAgeNotEqualToMaxAge = age != maxAge;

        Console.WriteLine($"Age is greater than minAge: {isAgeGreaterThanMinAge}");
        Console.WriteLine($"Age is less than minAge: {isAgeLessThanMinAge}");
        Console.WriteLine($"Age is greater than or equal to minAge: {isAgeGreaterOrEqualToMinAge}");
        Console.WriteLine($"Age is less than or equal to minAge: {isAgeLessOrEqualToMinAge}");
        Console.WriteLine($"Age is equal to minAge: {isAgeEqualToMinAge}");
        Console.WriteLine($"Age is not equal to minAge: {isAgeNotEqualToMinAge}");

        Console.WriteLine("\n");

        Console.WriteLine($"Age is greater than maxAge: {isAgeGreaterThanMaxAge}");
        Console.WriteLine($"Age is less than maxAge: {isAgeLessThanMaxAge}");
        Console.WriteLine($"Age is greater than or equal to maxAge: {isAgeGreaterOrEqualToMaxAge}");
        Console.WriteLine($"Age is less than or equal to maxAge: {isAgeLessOrEqualToMaxAge}");
        Console.WriteLine($"Age is equal to maxAge: {isAgeEqualToMaxAge}");
        Console.WriteLine($"Age is not equal to maxAge: {isAgeNotEqualToMaxAge}");
    }
}


