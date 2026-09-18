/*
    Elemental Duel v1.0\

    Premise:
        - A training simulation for elemental warriors. You pic your element, the enemy picks randomly. The better element wins the round

    Setup:
        - Three elements: Ice, Fire, Water
        - Win conditions: Water beats fire, Fire beats ice, Ice beats water
        - 5 rounds per match
    
    Rules:
        - Write a method GetWinner(string player, string enemy) that returns: "player", "enemy", or "draw"
        - Write a method GetRandomElement() that returns a random element string
        - Player picks their element once at the start by typing 1, 2 or 3
        - Invalid input -> sneer and re-prompt
        - Track player wins, enemy wins, draws 
        - After 5 rounds, print the match summary
    
    Expected output:
        Pick your element: 1-Ice 2-Fire 3-Water
        > 2
        You chose Fire.
        ---
        Round 1: You: Fire | Enemy: Ice → You win!
        Round 2: You: Fire | Enemy: Fire → Draw!
        ...
        Match over. You: 3 | Enemy: 1 | Draws: 1

*/
public class DailyEx005ElementalDuel()
{
    string player = "player";
    string enemy = "enemy";
    string draw = "draw";
    string fire = "fire";
    string water = "water";
    string ice = "ice";
    bool quitGame = false;
    int playerWins = 0;
    int enemywins = 0;
    int draws = 0;
    int currentRound = 0;
    int maxRounds = 5;
    bool playAgain = true;
    Random rand = new();

    public void RunApp()
    {
        Greet();
        RunRound();
    }

    private void Greet()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("ELEMENTAL DUEL V1.0");
        Console.WriteLine("------------------------");
    }

    private void RunRound()
    {
        do
        {
            Console.WriteLine("Pick your element:\n1 - Ice\n2 - Fire\n3 - Water\nQ - Quit game\n---");

            string playerChoosenElement = PlayerElementPick();
            if (quitGame) return;
            string enemyChoosenElement = GetRandomElement();

            Console.WriteLine($"You've chosen -- {playerChoosenElement} --");

            Console.WriteLine($"Enemy chose -- {enemyChoosenElement} --");

            string winner = GetWinner(playerChoosenElement, enemyChoosenElement);

            if (!quitGame)
            {
                if (winner == player)
                {
                    Console.WriteLine($"{player} wins this round");
                    playerWins++;   
                }
                else if (winner == enemy)
                {
                    Console.WriteLine($"{enemy} wins this round");
                    enemywins++;   
                }
                else if (winner == draw)
                {
                    Console.WriteLine("Draw");
                    draws++;
                }
                   
                TrackRounds();
                currentRound++;  
            }
        } while (playAgain && currentRound != maxRounds);
    }

    private string PlayerElementPick()
    {
        string playerChoosenElement = "";
        bool validPick = false;
        do
        {
            string? playerInput = Console.ReadLine();
            switch (playerInput)
            {
                case "1":
                    playerChoosenElement = ice;
                    validPick = true;
                    break;
                case "2":
                    playerChoosenElement = fire;
                    validPick = true;
                    break;
                case "3":
                    playerChoosenElement = water;
                    validPick = true;
                    break;
                case "q":
                    QuitGame();
                    validPick = true;
                    break;
                default:
                    InvalidInput();
                    break;
            }    
        } while (!validPick);
        
        return playerChoosenElement;
    }

    private string GetWinner(string player, string enemy)
    {
        string winner = "";
        if (player == fire)
        {
            if (enemy == ice) winner = this.player;
            else if (enemy == water) winner = this.enemy;
            else winner = draw;
        }
        else if (player == water)
        {
            if (enemy == fire) winner = this.player;
            else if (enemy == ice) winner = this.enemy;
            else winner = draw;
        }
        else if (player == ice)
        {
            if (enemy == water) winner = this.player;
            else if (enemy == fire) winner = this.enemy;
            else winner = draw;
        }
        return winner;
    }

    private string GetRandomElement()
    {
        string element = "";
        int choosenElement = rand.Next(1, 4);
        switch (choosenElement)
        {
            case 1:
                element = fire;
                break;
            case 2:
                element = water;
                break;
            case 3:
                element = ice;
                break;
        }
        return element;
    }

    private void TrackRounds()
    {
        Console.WriteLine("--------------");
        Console.WriteLine($"Player wins: {playerWins}");
        Console.WriteLine($"Enemy wins: {enemywins}");
        Console.WriteLine($"Draws: {draws}");
        Console.WriteLine("--------------");

        bool playerWinsMatch = playerWins == 3;
        bool enemyWinsMatch = enemywins == 3;

        if (playerWinsMatch)
        {
            Console.WriteLine("PLAYER WINS THE MATCH!");
            playAgain = false;
        }
        else if (enemyWinsMatch)
        {
            Console.WriteLine("ENEMY WINS THE MATCH!");
            playAgain = false;
        }
        else
        {
            if (currentRound == maxRounds)
            {
                if (playerWins > enemywins)
                {
                    Console.WriteLine("PLAYER WINS THE MATCH!");
                    playAgain = false;   
                }
                else if (enemywins > playerWins)
                {
                    Console.WriteLine("ENEMY WINS THE MATCH!");
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("MATCH IS A DRAW!");   
                    playAgain = false;
                }
            }
            else
            {
                Console.WriteLine("Play again(y/n)?");
                if (!(Console.ReadLine() == "y"))
                {
                    playAgain = false;
                    QuitGame();   
                }   
            }
        }   
    }

    private void InvalidInput()
    {
        Console.WriteLine("Invalid input. Please try again");
    }

    private void QuitGame()
    {
        quitGame = true;
        Console.WriteLine("Good bye.");
    }
}