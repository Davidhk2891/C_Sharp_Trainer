/*
Goal: Combine arrays, loops and conditionals to simulate a simple store system that tracks product inventory and flags invalid orders

Requirements:
1.	Have two arrays:
•	productNames → 5 products (strings)
•	productStock → matching stock counts (ints)
2.	Have an array of orderQuantities (ints) — simulate 5 customer orders (some valid, some invalid).
3.	For each order:
    •	Print the product name and requested quantity.
    •	If the requested quantity is greater than available stock, print:
        "Order for {product} is invalid — not enough stock."
    •	Otherwise:
        •	Deduct the ordered quantity from stock.
        •	Print: "Order for {product} completed. Remaining stock: {newStock}"
4.	After all orders are processed, print a summary showing all remaining stock per product.
*/
public class FraudOrderInventoryChecker
{
    public static void RunApp()
    {
        Console.WriteLine("\n");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("--- Fraud order & Inventory processor ---");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("\n");
        string[] productNames = { "Banana", "Garlic", "Red peppers", "Avocado", "Orange juice" };
        int[] stockCounts = { 54, 34, 33, 65, 21 };
        int[] orderQuantities = { 12, 20, 11, 68, 22 };
        int[] updatedStock = new int[5];
        int inventoryIndex = 0;

        foreach (string product in productNames)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Requested quanitity: {orderQuantities[inventoryIndex]}");
            if (orderQuantities[inventoryIndex] > stockCounts[inventoryIndex])
            {
                Console.WriteLine($"Order for {product} is invalid - not enough stock");
            }
            else
            {
                updatedStock[inventoryIndex] = stockCounts[inventoryIndex] - orderQuantities[inventoryIndex];
                Console.WriteLine($"Order for product {product} completed. Remaining stock: {updatedStock[inventoryIndex]}");
            }
            inventoryIndex++;
        }
        inventoryIndex = 0;
        Console.WriteLine("\n");
        Console.WriteLine("Remaining stock:\n");
        foreach (int productCount in updatedStock)
        {
            if (productCount <= 0)
            {
                Console.WriteLine($"Remaining stock for: {productNames[inventoryIndex]} - Customer emptied stock");
            }
            else
            {
                Console.WriteLine($"Remaining stock for: {productNames[inventoryIndex]} - {productCount}");   
            }
            inventoryIndex++;
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("\n");
    }
}