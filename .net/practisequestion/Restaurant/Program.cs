public class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool IsVegetarian { get; set; }

    public MenuItem(string name, string category, double price, bool isVeg)
    {
        ItemName = name;
        Category = category;
        Price = price;
        IsVegetarian = isVeg;
    }
}

public class MenuManager
{
    private List<MenuItem> menuItems = new List<MenuItem>();

    // Add Menu Item with Validation
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        if (price <= 0)
        {
            Console.WriteLine("Price must be greater than zero.");
            return;
        }

        menuItems.Add(new MenuItem(name, category, price, isVeg));
    }

    // Group Items By Category
    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return menuItems
               .GroupBy(item => item.Category)
               .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get Vegetarian Items
    public List<MenuItem> GetVegetarianItems()
    {
        return menuItems
               .Where(item => item.IsVegetarian)
               .ToList();
    }

    // Calculate Average Price By Category
    public double CalculateAveragePriceByCategory(string category)
    {
        var items = menuItems
                    .Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .ToList();

        if (items.Count == 0)
            return 0;

        return items.Average(item => item.Price);
    }
}

class Program
{
    static void Main()
    {
        MenuManager manager = new MenuManager();

        // 1️ Add Menu Items
        manager.AddMenuItem("Spring Rolls", "Appetizer", 120, true);
        manager.AddMenuItem("Chicken Wings", "Appetizer", 180, false);
        manager.AddMenuItem("Paneer Butter Masala", "Main Course", 250, true);
        manager.AddMenuItem("Chicken Biryani", "Main Course", 300, false);
        manager.AddMenuItem("Gulab Jamun", "Dessert", 90, true);

        // 2️ Display Categorized Menu
        Console.WriteLine("\nMenu By Category:");
        var grouped = manager.GroupItemsByCategory();

        foreach (var category in grouped)
        {
            Console.WriteLine($"\n{category.Key}");
            foreach (var item in category.Value)
            {
                Console.WriteLine($"{item.ItemName} - ₹{item.Price} - {(item.IsVegetarian ? "Veg" : "Non-Veg")}");
            }
        }

        // 3️ Vegetarian Menu
        Console.WriteLine("\nVegetarian Items:");
        var vegItems = manager.GetVegetarianItems();

        foreach (var item in vegItems)
        {
            Console.WriteLine($"{item.ItemName} - ₹{item.Price}");
        }

        // 4️ Average Price Per Category
        Console.WriteLine("\nAverage Price (Main Course): ₹" +
            manager.CalculateAveragePriceByCategory("Main Course"));
    }
}