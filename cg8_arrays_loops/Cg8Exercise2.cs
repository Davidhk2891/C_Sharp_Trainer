/*
Goal: Demonstrate you can use a foreach loop with a conditional statement isndie to filter array data

Scenario:
You're processing an order list for a store
You need to identify which order IDs are fraudulent - any ID below 1000 should be flagged

Instructions:
1.	Create an integer array of 6 order IDs (mix some below and above 1000).
2.	Loop through the array with foreach.
3.	For each order ID:
    •	If it’s below 1000 → print "Order {id} is fraudulent!"
    •	Otherwise → print "Order {id} is valid."
*/
public class Cg8Exercise2
{
    public static void Run()
    {
        Console.WriteLine("\n");
        Console.WriteLine("--- Order checker ---");
        int[] orderIDs = { 1254, 987, 556, 1054, 3421 };
        int threshold = 1000;
        foreach (int orderID in orderIDs)
        {
            if (orderID < threshold)
            {
                Console.WriteLine($"Order {orderID} is fraudulent!");
            }
            else
            {
                Console.WriteLine($"Order {orderID} is valid.");
            }
        }
        Console.WriteLine("---------------------");
        Console.WriteLine("\n");
    }
}