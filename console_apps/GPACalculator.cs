/*
Requirements:
	•	Declare the student’s name and at least 5 courses. Each course has:
	•	a name (string)
	•	a credit hours value (int)
	•	a grade value (int → 4 for A, 3 for B, etc.)
	•	Calculate the total credit hours (sum of all course credits).
	•	Calculate the total grade points (credit hours × grade, summed across all courses).
	•	Calculate the GPA = total grade points ÷ total credit hours.
	•	Print the result in a formatted output like:

Student: Sophia Johnson

Course                  Grade   Credit Hours
English 101             4       3
Algebra 101             3       3
Biology 101             3       4
Computer Science I      3       4
Psychology 101          4       3

Final GPA:              3.35
*/
public class GPACalculator
{
    public static void RunApp()
    {
        string studentName = "Sophia Johnson";
        int englishGrade = 4;
        int englishCreditHours = 3;
        int algebraGrade = 3;
        int algebraCreditHours = 3;
        int biologyGrade = 3;
        int biologyCreditHours = 4;
        int csGrade = 3;
        int csCreditHours = 4;
        int psycGrade = 4;
        int psycCreditHours = 3;
        int totalCredithours;
        int totalGradePoints;
        decimal GPA;
        int leadingDigit, firstDigit, secondDigit;


        // Calculate the total credit hours (sum of all course credits).
        totalCredithours = englishCreditHours + algebraCreditHours + biologyCreditHours + csCreditHours + psycCreditHours;

        // Calculate the total grade points (credit hours × grade, summed across all courses).
        totalGradePoints = (englishCreditHours * englishGrade) + (algebraCreditHours * algebraGrade)
         + (biologyCreditHours * biologyGrade) + (csCreditHours * csGrade) + (psycCreditHours * psycGrade);

        // Calculate the GPA = total grade points ÷ total credit hours.
        GPA = (decimal)totalGradePoints / totalCredithours;
        leadingDigit = (int)GPA;
        firstDigit = (int)(GPA * 10) % 10;
        secondDigit = (int)(GPA * 100) % 10;

        // Write the template
        Console.WriteLine($"Student: {studentName}\n");
        Console.WriteLine("Course\t\t\tGrade\tCredit Hours");
        Console.WriteLine($"English 101\t\t{englishGrade}\t{englishCreditHours}");
        Console.WriteLine($"Algebra 101\t\t{algebraGrade}\t{algebraCreditHours}");
        Console.WriteLine($"Biology 101\t\t{biologyGrade}\t{biologyCreditHours}");
        Console.WriteLine($"Computer Science I\t{csGrade}\t{csCreditHours}");
        Console.WriteLine($"Psychology 101\t\t{psycGrade}\t{psycCreditHours}\n");
        Console.WriteLine($"Final GPA\t\t{leadingDigit}.{firstDigit}{secondDigit}");
    }
}