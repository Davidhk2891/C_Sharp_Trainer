/*
Goal: Understand how to declare, access, and iterate through arrays using foreach

Instructions: You need to store the number of items in 5 wharehouse bins and print the total
1.	Create an integer array with 5 elements.
2.	Use a foreach loop to sum all items.
3.	Print each bin’s count and the running total after each iteration.
4.	Finally, print the total number of items in inventory.
*/
public class Cg8Exercise1
{
    public static void Run()
    {
        int totalItems = 0;
        int bin = 0;
        int[] wharehouse = new int[5];
        wharehouse[0] = 45;
        wharehouse[1] = 78;
        wharehouse[2] = 33;
        wharehouse[3] = 12;
        wharehouse[4] = 9;

        foreach (int itemsInBin in wharehouse)
        {
            totalItems += itemsInBin;
            bin++;
            Console.WriteLine($"Bin {bin} has {itemsInBin} items");
            Console.WriteLine($"The wharehouse has {totalItems} in the bins accounted for so far");
        }
        Console.WriteLine($"\nThe total amount of items from all combined bins is {totalItems}");
    }
}