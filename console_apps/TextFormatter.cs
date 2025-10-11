/*
Goal: Demonstrate you can use escape sequences, verbatim strings, unicode literals, and string interpolation to format multilingual output.
Instructions:
	1.	Create two variables:
	•	string projectName = "ACME";
	•	string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
(this is “View Russian output” in Russian)
	2.	Print this exact output (spacing and newlines must match):
        View English output:
            c:\Exercise\ACME\data.txt

        Посмотреть русский вывод:
            c:\Exercise\ACME\ru-RU\data.txt
*/
public class TextFormatter
{
    public static void RunApp()
    {
        string projectName = "ACME";
        string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";

        Console.WriteLine($"View English output:\n  c:\\Exercise\\{projectName}\\data.txt\n");
        Console.WriteLine($"{russianMessage}\n  c:\\Exercise\\{projectName}\\ru-RU\\data.txt");

    }   
}