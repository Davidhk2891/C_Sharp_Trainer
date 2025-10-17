/*
Goal: Use logical operators (&&, ||, !) to combine multiple comparisons into meaningful expressions
Instructions:
    1.Reuse or create new integer and boolean variables: age, hasLicenseYears, hasCleanRecord
    2. Write conditions that feel real:
        - Can a person rent a car (must be over 21, have a license  and a clean record)
        - Can a person get a discount (elder citizen)
        - Is a user disqualified
    3. Store each result in a boolean variable
    4. Print the outcome of each logical test
Tip: Keep variable names meaningful. E.g.: bool canRentCar, bool getDsciount, bool isDisqualified
*/
public class Cg10Exercise2
{
    public static void Run()
    {
        int age = 35;
        int hasLicenseYears = 3;
        bool hasCleanRecord = true;
        bool isResident = false;

        bool canRentCar = age > 18 && hasLicenseYears > 0 && hasCleanRecord;
        bool canGetDiscount = age > 65 && isResident;
        bool isDisqualified = hasLicenseYears == 0 || !hasCleanRecord;

        Console.WriteLine($"Can the customer rent a car?: {canRentCar}");
        Console.WriteLine($"Can the customer get a discount?: {canGetDiscount}");
        Console.WriteLine($"Is the customer disqualified to rent a car?: {isDisqualified}");
    }
}