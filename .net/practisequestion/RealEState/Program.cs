using System;
using System.Collections.Generic;
using System.Linq;

public class Property
{
    public string PropertyId { get; set; }
    public string Address { get; set; }
    public string PropertyType { get; set; }
    public int Bedrooms { get; set; }
    public double AreaSqFt { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public string Owner { get; set; }
}

public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string ClientType { get; set; }
    public double Budget { get; set; }
    public List<string> Requirements { get; set; } = new List<string>();
}

public class Viewing
{
    public int ViewingId { get; set; }
    public string PropertyId { get; set; }
    public int ClientId { get; set; }
    public DateTime ViewingDate { get; set; }
    public string Feedback { get; set; }
}

public class RealEstateManager
{
    private List<Property> properties = new List<Property>();
    private List<Client> clients = new List<Client>();
    private List<Viewing> viewings = new List<Viewing>();

    private int propertyCounter = 1;
    private int clientCounter = 1;
    private int viewingCounter = 1;

    public void AddProperty(string address, string type, int bedrooms,
                           double area, double price, string owner)
    {
        properties.Add(new Property
        {
            PropertyId = "PR" + propertyCounter++,
            Address = address,
            PropertyType = type,
            Bedrooms = bedrooms,
            AreaSqFt = area,
            Price = price,
            Status = "Available",
            Owner = owner
        });
    }

    public void AddClient(string name, string contact, string type,
                          double budget, List<string> requirements)
    {
        clients.Add(new Client
        {
            ClientId = clientCounter++,
            Name = name,
            Contact = contact,
            ClientType = type,
            Budget = budget,
            Requirements = requirements
        });
    }

    public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
    {
        var property = properties.FirstOrDefault(p => p.PropertyId == propertyId && p.Status == "Available");
        var client = clients.FirstOrDefault(c => c.ClientId == clientId);

        if (property == null || client == null) return false;

        viewings.Add(new Viewing
        {
            ViewingId = viewingCounter++,
            PropertyId = propertyId,
            ClientId = clientId,
            ViewingDate = date
        });

        return true;
    }

    public Dictionary<string, List<Property>> GroupPropertiesByType()
    {
        return properties
            .GroupBy(p => p.PropertyType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
    {
        return properties
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Status == "Available")
            .ToList();
    }

    public List<Property> GetAllProperties()
    {
        return properties;
    }
}

public class Program
{
    public static void Main()
    {
        RealEstateManager manager = new RealEstateManager();

        manager.AddProperty("Delhi Sector 21", "Apartment", 3, 1500, 7500000, "Mr. Sharma");
        manager.AddProperty("Mumbai Andheri", "Villa", 5, 3500, 25000000, "Mr. Mehta");

        manager.AddClient("Shubhankar", "9999999999", "Buyer", 8000000,
            new List<string> { "3BHK", "Near Metro" });

        manager.AddClient("Rahul", "8888888888", "Buyer", 30000000,
            new List<string> { "Villa", "Garden" });

        manager.ScheduleViewing("PR1", 1, DateTime.Now.AddDays(2));

        Console.WriteLine("Properties Grouped By Type:");
        var grouped = manager.GroupPropertiesByType();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var prop in group.Value)
            {
                Console.WriteLine($"{prop.PropertyId} - {prop.Address}");
            }
        }

        Console.WriteLine("\nProperties Within Budget (5M - 10M):");
        foreach (var prop in manager.GetPropertiesInBudget(5000000, 10000000))
        {
            Console.WriteLine($"{prop.PropertyId} - {prop.Price}");
        }
    }
}
