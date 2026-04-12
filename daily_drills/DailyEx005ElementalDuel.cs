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
    /*
        1. Write method GetWinner
        2. Write a method GetRandomElement() that returns a random element string
        3. Player picks their element once at the start by typing 1, 2 or 3
    */

    string player = "player";
    string enemy = "enemy";
    string draw = "draw";
    string fire = "fire";
    string water = "water";
    string ice = "ice";

    public void RunApp()
    {
        Greet();
    }

    private void Greet()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("ELEMENTAL DUEL V1.0");
        Console.WriteLine("------------------------");
        Console.WriteLine("Pick your element:\n1 - Ice\n2 - Fire\n3 - Water\n---");
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
        Random rand = new();
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
}