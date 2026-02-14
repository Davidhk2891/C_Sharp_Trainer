/*
Goal:
Practice loops, conditionals, random numbers, and counters.

Instructions:
	1.	Two players (Player and Computer) each roll a six-sided dice three times.
	2.	Print each roll for both players.
	3.	After three rounds, display each player’s total score.
	4.	Announce the winner (or a draw if tied).

Rules:
	•	Use a for loop for the three rounds.
	•	Use a Random object to simulate dice rolls (values 1–6).
	•	Keep running totals for both players.

Bonus:
Add a short delay between rolls (you’ve seen Thread.Sleep()).
*/
public class DailyEx003DiceBattle
{
    public static void RunApp()
    {
        Random rollDice = new();
        int playerRoll;
        int computerRoll;
        int playerRollsSum = 0;
        int computerRollsSum = 0;
        int totalRounds = 3;
        int currentRound;
        string outcomeMessage;
        bool playerWins;
        bool computerWins;

        // Program greetings
        Console.WriteLine("----------------------------");
        Console.WriteLine("DICE BATTLE V1.0");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Press Enter to run game");
        Console.ReadLine();
        for (int i = 1; i <= totalRounds; i++)
        {
            currentRound = i;
            playerRoll = rollDice.Next(1, 7);
            computerRoll = rollDice.Next(1, 7);

            playerRollsSum += playerRoll;
            computerRollsSum += computerRoll;

            Console.WriteLine("-----------------");
            Console.WriteLine($"Round {currentRound}:\n\nPlayer roll: {playerRoll}\nComputer roll: {computerRoll}");
            Console.WriteLine("-----");
            Console.WriteLine($"Totals:\n\nPlayer total: {playerRollsSum}\nComputer total: {computerRollsSum}");
            Console.WriteLine("----------------");
            Thread.Sleep(1500);
        }

        playerWins = playerRollsSum > computerRollsSum;
        computerWins = playerRollsSum < computerRollsSum;

        if (playerWins)
        {
            outcomeMessage = $"\nTotal player rolls: {playerRollsSum}\nTotal computer rolls: {computerRollsSum}\n\nPlayer wins!";
        }
        else if (computerWins)
        {
            outcomeMessage = $"\nTotal player rolls: {playerRollsSum}\nTotal computer rolls: {computerRollsSum}\n\nComputer wins!";
        }
        else
        {
            outcomeMessage = $"\nTotal player rolls: {playerRollsSum}\nTotal computer rolls: {computerRollsSum}\n\nDraw!";
        }

        Console.WriteLine(outcomeMessage);
    }
}