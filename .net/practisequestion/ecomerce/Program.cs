public class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public Product(string code, string name, string category, double price, int stock)
    {
        ProductCode = code;
        ProductName = name;
        Category = category;
        Price = price;
        StockQuantity = stock;
    }
}

public class InventoryManager
{
    private List<Product> products = new List<Product>();
    private int productCounter = 1;

    // Add Product with Auto Code
    public void AddProduct(string name, string category, double price, int stock)
    {
        if (price <= 0 || stock < 0)
        {
            Console.WriteLine("Invalid price or stock value.");
            return;
        }

        string code = "P" + productCounter.ToString("D3");
        productCounter++;

        products.Add(new Product(code, name, category, price, stock));
    }

    // Group Products By Category
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        SortedDictionary<string, List<Product>> grouped = new SortedDictionary<string, List<Product>>();

        foreach (var product in products)
        {
            if (!grouped.ContainsKey(product.Category))
                grouped[product.Category] = new List<Product>();

            grouped[product.Category].Add(product);
        }

        return grouped;
    }

    // Update Stock After Sale
    public bool UpdateStock(string productCode, int quantity)
    {
        var product = products.FirstOrDefault(p => 
                        p.ProductCode.Equals(productCode, StringComparison.OrdinalIgnoreCase));

        if (product == null || product.StockQuantity < quantity)
            return false;

        product.StockQuantity -= quantity;
        return true;
    }

    // Get Products Below Price
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products
               .Where(p => p.Price <= maxPrice)
               .ToList();
    }

    // Category Stock Summary
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return products
               .GroupBy(p => p.Category)
               .ToDictionary(g => g.Key, g => g.Sum(p => p.StockQuantity));
    }
}

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        // 1️ Add Products
        manager.AddProduct("Laptop", "Electronics", 70000, 10);
        manager.AddProduct("T-Shirt", "Clothing", 1200, 50);
        manager.AddProduct("Novel", "Books", 500, 30);
        manager.AddProduct("Headphones", "Electronics", 2500, 20);

        // 2️ Display Products By Category
        Console.WriteLine("\nProducts By Category:");
        var grouped = manager.GroupProductsByCategory();

        foreach (var category in grouped)
        {
            Console.WriteLine($"\n{category.Key}");
            foreach (var product in category.Value)
            {
                Console.WriteLine($"{product.ProductCode} - {product.ProductName} - ₹{product.Price} - Stock:{product.StockQuantity}");
            }
        }

        // 3️ Update Stock
        Console.WriteLine("\nUpdating Stock (Selling 2 Laptops)");
        bool updated = manager.UpdateStock("P001", 2);
        Console.WriteLine(updated ? "Stock Updated" : "Stock Update Failed");

        // 4️ Products Under Budget
        Console.WriteLine("\nProducts Below ₹3000:");
        var cheapProducts = manager.GetProductsBelowPrice(3000);

        foreach (var product in cheapProducts)
        {
            Console.WriteLine($"{product.ProductName} - ₹{product.Price}");
        }

        // 5️ Inventory Summary
        Console.WriteLine("\nCategory Stock Summary:");
        var summary = manager.GetCategoryStockSummary();

        foreach (var item in summary)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}