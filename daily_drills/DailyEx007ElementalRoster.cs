/*
    Premise:
        - Before the tournament begins, the arena master reveals the roster. Four warriors
        enter. Each is randomly assigned an element. The crowd watches in silence as each name is called.
    
    Setup:
        - Four harcoded player names stored in a string array
        - Each player is randomly assigned an Element using GetRandomElement()
        - Names revealed one at a time with a pause between each

    Rules:
        - Declare a string[] of 4 hardcoded player names
        - Declare an Element[] of 4 elements, assigned via GetRandomElement()
        - Use a for loop to assign and print each player's name and element
        - Print names in ALL CAPS using ToUpper()
        - Use Thread.Sleep(1000) between each reveal
        - Reuse your Element enum and GetRandomElement() method from previous exercises

    Exepcted output
    --- THE ROSTER ---
    ASHVEIL - Fire
    DREADMAW - Water
    THE HOLLOW - Ice
    SERAPHON - Fire
*/
public class DailyEx007ElementalRoster
{
    private Random rng = new();
    private string[] warriorsNames = [ "Ashveil", "Dreadmaw", "The hollow", "Seraphon" ];
    private Elements[] warriorElements = new Elements[4];

    private enum Elements
    {
        Ice,
        Fire,
        Water,
        None
    }
    public void RunApp()
    {
        GreetPlayer();
        AssignElementsToWarriors();
        RunRoster();
    }

    private void GreetPlayer()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine("- ELEMENTAL ROSTER -");
        DrawLine();
    }

    private void RunRoster()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Warrior: {warriorsNames[i].ToUpper()} | Element: {warriorElements[i]}");
        }
        DrawLine();
        Thread.Sleep(1000);
        Console.WriteLine("Let the duels begin...");
        DrawLine();
    }

    private void AssignElementsToWarriors()
    {
        for (int i = 0; i < warriorsNames.Length; i++)
        {
            warriorElements[i] = GetRandomElement();

        }
    }

    private Elements GetRandomElement()
    {
        int elementIndex = rng.Next(1, 4);
        Elements element;
        switch (elementIndex)
        {
            case 1:
                element = Elements.Ice;
                break;
            case 2:
                element = Elements.Fire;
                break;
            case 3:
                element = Elements.Water;
                break;
            default:
                element = Elements.None;
                break;
        }       
        return element;
    }

    private void DrawLine()
    {
        Console.WriteLine("--------------------");
    }
}