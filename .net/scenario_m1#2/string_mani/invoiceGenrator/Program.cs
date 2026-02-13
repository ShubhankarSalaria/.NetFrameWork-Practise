using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        StringBuilder invoice = new StringBuilder();

        decimal grandTotal = 0;

        invoice.AppendLine("========== INVOICE ==========");
        invoice.AppendLine($"{"Item",-15} {"Qty",-5} {"Price",-10} {"Total",-10}");
        invoice.AppendLine("------------------------------------------");

        for (int i = 1; i <= 1; i++)
        {
            Console.WriteLine($"Enter details for Item {i}");

            Console.Write("Item Name: ");
            string itemName = Console.ReadLine();

            Console.Write("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            decimal lineTotal = qty * price;
            grandTotal += lineTotal;

            invoice.AppendLine($"{itemName,-15} {qty,-5} {price,-10} {lineTotal,-10}");
            Console.WriteLine();
        }

        invoice.AppendLine("------------------------------------------");
        invoice.AppendLine($"Grand Total: {grandTotal}");
        invoice.AppendLine("==========================================");

        Console.WriteLine();
        Console.WriteLine(invoice.ToString());
    }
}
