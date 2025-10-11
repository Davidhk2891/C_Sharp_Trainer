/*
Goal: Calculate the average grade for each student, then display results in a table.

You’re given the following data (5 assignments per student):
	•	Sophia: 93, 87, 98, 95, 100
	•	Nicolas: 80, 83, 82, 88, 85
	•	Zahirah: 84, 96, 73, 85, 79
	•	Jeong: 90, 92, 98, 100, 97

Requirements:
	1.	Set a variable to represent the total number of assignments.
	2.	Declare variables for each student’s scores.
	3.	Calculate the sum of scores for each student.
	4.	Calculate the average (decimal) for each student.
	5.	Print results in a table, like this:
        Student        Grade
        Sophia         94  A
        Nicolas        83  B
        Zahirah        83  B
        Jeong          95  A
    Hint:
	•	You’ll need to cast to decimal to avoid integer truncation.
	•	Use \t (tabs) in your output to align columns.
	•	Assign a letter grade (A/B) in the output, based on the average.
*/
public class ScoreCalculator
{
	public static void RunApp()
	{
		int totalNumAssignments = 5;

		int sophiaScore1 = 93;
		int sophiaScore2 = 87;
		int sophiaScore3 = 98;
		int sophiaScore4 = 95;
		int sophiaScore5 = 100;

		int nicolasScore1 = 80;
		int nicolasScore2 = 83;
		int nicolasScore3 = 82;
		int nicolasScore4 = 88;
		int nicolasScore5 = 85;

		int zahirahScore1 = 84;
		int zahirahScore2 = 96;
		int zahirahScore3 = 73;
		int zahirahScore4 = 85;
		int zahirahScore5 = 79;

		int jeongScore1 = 90;
		int jeongScore2 = 92;
		int jeongScore3 = 98;
		int jeongScore4 = 100;
		int jeongScore5 = 97;

		int sophiaTotalScore = sophiaScore1 + sophiaScore2 + sophiaScore3 + sophiaScore4 + sophiaScore5;
		int nicolasTotalScore = nicolasScore1 + nicolasScore2 + nicolasScore3 + nicolasScore4 + nicolasScore5;
		int zahirahTotalScore = zahirahScore1 + zahirahScore2 + zahirahScore3 + zahirahScore4 + zahirahScore5;
		int jeongTotalScore = jeongScore1 + jeongScore2 + jeongScore3 + jeongScore4 + jeongScore5;

		decimal sophiaAvg = (decimal)sophiaTotalScore / totalNumAssignments;
		decimal nicolasAvg = (decimal)nicolasTotalScore / totalNumAssignments;
		decimal jeongAvg = (decimal)jeongTotalScore / totalNumAssignments;
		decimal zahirahAvg = (decimal)zahirahTotalScore / totalNumAssignments;

		Console.WriteLine("Student\t\tGrade");
		Console.WriteLine($"Sophia\t\t{sophiaAvg} A");
		Console.WriteLine($"nicolas\t\t{nicolasAvg} B");
		Console.WriteLine($"Zahirah\t\t{zahirahAvg} B");
		Console.WriteLine($"Jeong\t\t{jeongAvg} A");
    }
}