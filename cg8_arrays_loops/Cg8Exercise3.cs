/*
Goal: Combine arrays, loops and string methods to perform a filter-like operation

Scenario: 
- You're managing a store inventory with product names.
- You want to print only the products that start with the letter B

Instructions:
1.	Create a string[] called products with at least 6 items (e.g., "Banana", "apple", "Bread", "milk", etc.).
2.	Use a foreach loop to go through each product.
3.	Inside the loop, check if the product starts with 'B' or 'b'.
4.	Print only those products that match.
*/
public class Cg8Exercise3
{
    public static void Run()
    {
        Console.WriteLine("\n");
        Console.WriteLine("--- Inventory filterer ---");
        string[] products = ["Banana", "Apple", "Bread", "Eggs", "Milk", "Whole chicken"];
        foreach (string product in products)
        {
            if (product.StartsWith("B") || product.StartsWith("b"))
            {
                Console.WriteLine(product);
            }
        }
        Console.WriteLine("--------------------------");
        Console.WriteLine("\n");
    }
}