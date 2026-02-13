using System;
using System.Collections.Generic;
using System.Linq;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string CuisineType { get; set; }
    public string Location { get; set; }
    public double DeliveryCharge { get; set; }

    public Restaurant(int id, string name, string cuisine, string location, double charge)
    {
        RestaurantId = id;
        Name = name;
        CuisineType = cuisine;
        Location = location;
        DeliveryCharge = charge;
    }
}

public class FoodItem
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int RestaurantId { get; set; }

    public FoodItem(int id, int restaurantId, string name, string category, double price)
    {
        ItemId = id;
        RestaurantId = restaurantId;
        Name = name;
        Category = category;
        Price = price;
    }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<FoodItem> Items { get; set; }
    public DateTime OrderTime { get; set; }
    public string Status { get; set; }
    public double TotalAmount { get; set; }

    public Order(int id, int customerId, List<FoodItem> items, double total)
    {
        OrderId = id;
        CustomerId = customerId;
        Items = items;
        TotalAmount = total;
        OrderTime = DateTime.Now;
        Status = "Pending";
    }
}

public class DeliveryManager
{
    private List<Restaurant> restaurants = new List<Restaurant>();
    private List<FoodItem> foodItems = new List<FoodItem>();
    private List<Order> orders = new List<Order>();

    private int restaurantCounter = 1;
    private int itemCounter = 1;
    private int orderCounter = 1;

    public void AddRestaurant(string name, string cuisine, string location, double charge)
    {
        if (charge < 0) return;
        restaurants.Add(new Restaurant(restaurantCounter++, name, cuisine, location, charge));
    }

    public void AddFoodItem(int restaurantId, string name, string category, double price)
    {
        if (price <= 0) return;

        if (restaurants.Any(r => r.RestaurantId == restaurantId))
        {
            foodItems.Add(new FoodItem(itemCounter++, restaurantId, name, category, price));
        }
    }

    public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
    {
        return restaurants
            .GroupBy(r => r.CuisineType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public bool PlaceOrder(int customerId, List<int> itemIds)
    {
        var selectedItems = foodItems
            .Where(i => itemIds.Contains(i.ItemId))
            .ToList();

        if (!selectedItems.Any())
            return false;

        int restaurantId = selectedItems.First().RestaurantId;

        if (selectedItems.Any(i => i.RestaurantId != restaurantId))
            return false;

        var restaurant = restaurants.First(r => r.RestaurantId == restaurantId);

        double total = selectedItems.Sum(i => i.Price) + restaurant.DeliveryCharge;

        orders.Add(new Order(orderCounter++, customerId, selectedItems, total));

        return true;
    }

    public List<Order> GetPendingOrders()
    {
        return orders
            .Where(o => o.Status == "Pending")
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        DeliveryManager manager = new DeliveryManager();

        manager.AddRestaurant("Spice Hub", "Indian", "Jaipur", 50);
        manager.AddRestaurant("Dragon Bowl", "Chinese", "Delhi", 60);

        manager.AddFoodItem(1, "Paneer Butter Masala", "Main Course", 250);
        manager.AddFoodItem(1, "Naan", "Bread", 40);
        manager.AddFoodItem(2, "Hakka Noodles", "Main Course", 180);

        manager.PlaceOrder(101, new List<int> { 1, 2 });

        var grouped = manager.GroupRestaurantsByCuisine();
        foreach (var cuisine in grouped)
        {
            Console.WriteLine(cuisine.Key);
            foreach (var restaurant in cuisine.Value)
            {
                Console.WriteLine(restaurant.Name);
            }
        }

        var pendingOrders = manager.GetPendingOrders();
        foreach (var order in pendingOrders)
        {
            Console.WriteLine($"{order.OrderId} - {order.TotalAmount}");
        }
    }
}
