using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public string Supplier { get; set; }
    public double UnitPrice { get; set; }
    public int CurrentStock { get; set; }
    public int MinimumStockLevel { get; set; }
}

public class StockMovement
{
    public int MovementId { get; set; }
    public string ProductCode { get; set; }
    public DateTime MovementDate { get; set; }
    public string MovementType { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
}

public class InventoryManager
{
    private List<Product> products = new List<Product>();
    private List<StockMovement> movements = new List<StockMovement>();
    private int movementCounter = 1;

    public void AddProduct(string code, string name, string category,
                          string supplier, double price, int stock, int minLevel)
    {
        products.Add(new Product
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Supplier = supplier,
            UnitPrice = price,
            CurrentStock = stock,
            MinimumStockLevel = minLevel
        });
    }

    public bool UpdateStock(string productCode, string movementType,
                           int quantity, string reason)
    {
        var product = products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null || quantity <= 0) return false;

        if (movementType == "Out" && product.CurrentStock < quantity)
            return false;

        if (movementType == "In")
            product.CurrentStock += quantity;
        else if (movementType == "Out")
            product.CurrentStock -= quantity;
        else
            return false;

        movements.Add(new StockMovement
        {
            MovementId = movementCounter++,
            ProductCode = productCode,
            MovementDate = DateTime.Now,
            MovementType = movementType,
            Quantity = quantity,
            Reason = reason
        });

        return true;
    }

    public Dictionary<string, List<Product>> GroupProductsByCategory()
    {
        return products
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Product> GetLowStockProducts()
    {
        return products
            .Where(p => p.CurrentStock <= p.MinimumStockLevel)
            .ToList();
    }

    public Dictionary<string, int> GetStockValueByCategory()
    {
        return products
            .GroupBy(p => p.Category)
            .ToDictionary(
                g => g.Key,
                g => (int)g.Sum(p => p.UnitPrice * p.CurrentStock)
            );
    }

    public List<Product> GetAllProducts()
    {
        return products;
    }
}

public class Program
{
    public static void Main()
    {
        InventoryManager manager = new InventoryManager();

        manager.AddProduct("P001", "Laptop", "Electronics", "Dell", 70000, 10, 3);
        manager.AddProduct("P002", "Mouse", "Electronics", "Logitech", 800, 50, 10);
        manager.AddProduct("P003", "Chair", "Furniture", "IKEA", 5000, 5, 2);

        manager.UpdateStock("P001", "Out", 2, "Sale");
        manager.UpdateStock("P003", "Out", 4, "Sale");
        manager.UpdateStock("P002", "In", 20, "Purchase");

        Console.WriteLine("Products Grouped By Category:");
        var grouped = manager.GroupProductsByCategory();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var product in group.Value)
            {
                Console.WriteLine($"{product.ProductName} - Stock: {product.CurrentStock}");
            }
        }

        Console.WriteLine("\nLow Stock Products:");
        foreach (var product in manager.GetLowStockProducts())
        {
            Console.WriteLine(product.ProductName);
        }

        Console.WriteLine("\nStock Value By Category:");
        var values = manager.GetStockValueByCategory();
        foreach (var item in values)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}
