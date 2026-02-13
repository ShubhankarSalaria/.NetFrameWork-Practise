using System;
using System.Collections.Generic;
using System.Linq;

public class Package
{
    public string TrackingNumber { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string DestinationAddress { get; set; }
    public double Weight { get; set; }
    public string PackageType { get; set; }
    public double ShippingCost { get; set; }
}

public class DeliveryStatus
{
    public string TrackingNumber { get; set; }
    public List<string> Checkpoints { get; set; } = new List<string>();
    public string CurrentStatus { get; set; }
    public DateTime EstimatedDelivery { get; set; }
    public DateTime ActualDelivery { get; set; }
}

public class CourierManager
{
    private List<Package> packages = new List<Package>();
    private List<DeliveryStatus> statuses = new List<DeliveryStatus>();
    private int trackingCounter = 1;

    public void AddPackage(string sender, string receiver, string address,
                           double weight, string type, double cost)
    {
        string trackingNumber = "TRK" + trackingCounter++;

        packages.Add(new Package
        {
            TrackingNumber = trackingNumber,
            SenderName = sender,
            ReceiverName = receiver,
            DestinationAddress = address,
            Weight = weight,
            PackageType = type,
            ShippingCost = cost
        });

        statuses.Add(new DeliveryStatus
        {
            TrackingNumber = trackingNumber,
            CurrentStatus = "Dispatched",
            EstimatedDelivery = DateTime.Now.AddDays(5)
        });
    }

    public bool UpdateStatus(string trackingNumber, string status,
                             string checkpoint)
    {
        var delivery = statuses.FirstOrDefault(s => s.TrackingNumber == trackingNumber);
        if (delivery == null) return false;

        delivery.CurrentStatus = status;
        delivery.Checkpoints.Add($"{DateTime.Now}: {checkpoint}");

        if (status == "Delivered")
            delivery.ActualDelivery = DateTime.Now;

        return true;
    }

    public Dictionary<string, List<Package>> GroupPackagesByType()
    {
        return packages
            .GroupBy(p => p.PackageType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Package> GetPackagesByDestination(string city)
    {
        return packages
            .Where(p => p.DestinationAddress
            .Contains(city, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Package> GetDelayedPackages()
    {
        return statuses
            .Where(s => s.CurrentStatus != "Delivered" &&
                        DateTime.Now > s.EstimatedDelivery)
            .Join(packages,
                  s => s.TrackingNumber,
                  p => p.TrackingNumber,
                  (s, p) => p)
            .ToList();
    }

    public List<Package> GetAllPackages()
    {
        return packages;
    }
}

public class Program
{
    public static void Main()
    {
        CourierManager manager = new CourierManager();

        manager.AddPackage("Shubhankar", "Rahul", "Mumbai", 2.5, "Parcel", 500);
        manager.AddPackage("Amit", "Neha", "Delhi", 1.2, "Document", 200);

        var allPackages = manager.GetAllPackages();
        string tracking1 = allPackages[0].TrackingNumber;

        manager.UpdateStatus(tracking1, "InTransit", "Reached Jaipur Hub");
        manager.UpdateStatus(tracking1, "Delivered", "Delivered to Receiver");

        Console.WriteLine("Packages Grouped By Type:");
        var grouped = manager.GroupPackagesByType();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var pkg in group.Value)
            {
                Console.WriteLine($"{pkg.TrackingNumber} -> {pkg.ReceiverName}");
            }
        }

        Console.WriteLine("\nPackages To Delhi:");
        foreach (var pkg in manager.GetPackagesByDestination("Delhi"))
        {
            Console.WriteLine(pkg.TrackingNumber);
        }

        Console.WriteLine("\nDelayed Packages:");
        foreach (var pkg in manager.GetDelayedPackages())
        {
            Console.WriteLine(pkg.TrackingNumber);
        }
    }
}
