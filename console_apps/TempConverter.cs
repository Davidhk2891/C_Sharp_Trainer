/*
Goal: Demonstrate you can do arithmetic with variables, apply a formula, and output the result.
Instructions:
	1.	Create a variable double fahrenheit = 94;
	2.	Convert it to Celsius using the formula:
        celsius = (fahrenheit - 32) \times 5 / 9
	3.	Print the result in this exact format:
        The temperature is 34.4444444444444 Celsius
    👉 Use interpolation, one Console.WriteLine.
*/
public class TempConverter
{
    public static void RunApp()
    {
        double fahrenheit = 94;
        double celsius = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine($"The temperature is {celsius} Celsius");
    }
}