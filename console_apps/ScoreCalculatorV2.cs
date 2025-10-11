/*
Goal: Build a console application that calculates each student’s average score (including extra credit), assigns a letter grade,
and prints a clean report of all students and their final results.

Data:
Student Scores
Sophia  90, 86, 87, 98, 100, 90, 94
Nicolas 92, 89, 81, 96, 90, 89
Zahirah 84, 93, 75, 87, 97, 89, 89, 89
Jeong   90, 92, 98, 100, 97, 96
Becky   92, 91, 90, 91, 92, 92, 92
Chris   84, 86, 88, 90, 92, 94, 96, 98
Eric    80, 90, 100, 80, 90, 100, 80, 90
Gregor  91, 91, 91, 91, 91, 91, 91

Letter grades
97+    A+
93–96  A
90–92  A–
87–89  B+
83–86  B
80–82  B–
77–79  C+
73–76  C
70–72  C–
67–69  D+
63–66  D
60–62  D–
<60    F

Formulas:
Average score = (sum of exams + extra credit bonus) / 5
Extra credit bonus = 10% of extra credit score -> extra credit score / 10

UI:
---------------------------
STUDENT GRADER v2.0
---------------------------

Student         Grade

Sophia          94.8    A
Nicolas         89.3    B+
Zahirah         88.0    B+
Jeong           96.2    A
Becky           91.4    A-
Chris           91.0    A-
Eric            86.0    B
Gregor          91.0    A-

---------------------------
Press any key to continue...

Break down the big problem into smaller problems
*/
public class ScoreCalculatorV2
{
    public static void RunApp()
    {
        // Declare and initialize total assignments and student scores
        int examAssignments = 5;

        int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 90, 94 };
        int[] nicolasScores = new int[] { 92, 89, 81, 96, 90, 89 };
        int[] zahirahScores = new int[] { 84, 92, 75, 87, 97, 89, 89, 89 };
        int[] jeongScores = new int[] { 90, 92, 98, 100, 97, 96 };
        int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
        int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
        int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
        int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };

        // You want to handle all operations per student. So create a string array containing all student names
        string[] studentNames = new string[] { "Sophia", "Nicolas", "Zahirah", "Jeong", "Becky", "Chris", "Eric", "Gregor" };

        // Declare generic student's grade list
        int[] currentStudentScores = new int[10];

        // Print app headers
        Console.WriteLine("---------------------");
        Console.WriteLine("SCORE CALCULATOR V2.0");
        Console.WriteLine("---------------------");

        // Print labels
        Console.WriteLine("---------------------");
        Console.WriteLine("Student\t\tGrade");

        // Iterate through all names. All operations per student will happen here
        foreach (string name in studentNames)
        {
            // Declare and assign current student to its name from student's list
            string currentStudent = name;

            // Declare/reset total scores
            int studentScoresSum = 0;

            // Declare/reset scores average
            decimal studentScoresAvg = 0;

            // Declare/reset letter grade
            string letterGrade = "";

            // assign current student's scores list to generic student's scores list
            if (name == "Sophia")
                currentStudentScores = sophiaScores;

            else if (name == "Nicolas")
                currentStudentScores = nicolasScores;

            else if (name == "Zahirah")
                currentStudentScores = zahirahScores;

            else if (name == "Jeong")
                currentStudentScores = jeongScores;

            else if (name == "Becky")
                currentStudentScores = beckyScores;

            else if (name == "Chris")
                currentStudentScores = chrisScores;

            else if (name == "Eric")
                currentStudentScores = ericScores;

            else if (name == "Gregor")
                currentStudentScores = gregorScores;

            else
                continue;

            // Calculate current student's grades sum. Including extra assignemnts which are worth 10% of grade
            int currentAssignmentIndex = 0;
            foreach (int currentScore in currentStudentScores)
            {
                currentAssignmentIndex++;
                if (currentAssignmentIndex <= examAssignments)
                {
                    // Sum exam score to score total
                    studentScoresSum += currentScore;
                }
                else
                {
                    studentScoresSum += currentScore / 10;
                }
            }

            // Calculate student's score average
            studentScoresAvg = (decimal)studentScoresSum / examAssignments;

            // Calculate letter grades
            if (studentScoresAvg >= 97)
                letterGrade = "A+";

            else if (studentScoresAvg >= 93)
                letterGrade = "A";

            else if (studentScoresAvg >= 90)
                letterGrade = "A-";

            else if (studentScoresAvg >= 87)
                letterGrade = "B+";

            else if (studentScoresAvg >= 83)
                letterGrade = "B";

            else if (studentScoresAvg >= 80)
                letterGrade = "B-";

            else if (studentScoresAvg >= 77)
                letterGrade = "C+";

            else if (studentScoresAvg >= 73)
                letterGrade = "C";

            else if (studentScoresAvg >= 70)
                letterGrade = "C-";

            else if (studentScoresAvg >= 67)
                letterGrade = "D+";

            else if (studentScoresAvg >= 63)
                letterGrade = "D";

            else if (studentScoresAvg >= 60)
                letterGrade = "D-";

            else
                letterGrade = "F";    

            // Print student's name, score and letter grade
            Console.WriteLine($"{currentStudent}\t\t{studentScoresAvg:F1}\t{letterGrade}");
        }

        Console.WriteLine("---------------------");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }
}