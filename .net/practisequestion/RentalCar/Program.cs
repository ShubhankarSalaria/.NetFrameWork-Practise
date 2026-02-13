using System;
using System.Collections.Generic;
using System.Linq;

public class RentalCar
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string CarType { get; set; }
    public bool IsAvailable { get; set; }
    public double DailyRate { get; set; }

    public RentalCar(string license, string make, string model, string type, double rate)
    {
        LicensePlate = license;
        Make = make;
        Model = model;
        CarType = type;
        DailyRate = rate;
        IsAvailable = true;
    }
}

public class Rental
{
    public int RentalId { get; set; }
    public string LicensePlate { get; set; }
    public string CustomerName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalCost { get; set; }

    public Rental(int id, string license, string customer, DateTime start, DateTime end, double cost)
    {
        RentalId = id;
        LicensePlate = license;
        CustomerName = customer;
        StartDate = start;
        EndDate = end;
        TotalCost = cost;
    }
}

public class RentalManager
{
    private List<RentalCar> cars = new List<RentalCar>();
    private List<Rental> rentals = new List<Rental>();
    private int rentalCounter = 1;

    public void AddCar(string license, string make, string model, string type, double rate)
    {
        if (rate <= 0) return;
        cars.Add(new RentalCar(license, make, model, type, rate));
    }

    public bool RentCar(string license, string customer, DateTime start, int days)
    {
        var car = cars.FirstOrDefault(c =>
            c.LicensePlate.Equals(license, StringComparison.OrdinalIgnoreCase));

        if (car == null || !car.IsAvailable || days <= 0)
            return false;

        DateTime end = start.AddDays(days);
        double cost = days * car.DailyRate;

        rentals.Add(new Rental(rentalCounter++, license, customer, start, end, cost));
        car.IsAvailable = false;

        return true;
    }

    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        return cars
            .Where(c => c.IsAvailable)
            .GroupBy(c => c.CarType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Rental> GetActiveRentals()
    {
        DateTime now = DateTime.Now;

        return rentals
            .Where(r => r.StartDate <= now && r.EndDate >= now)
            .ToList();
    }

    public double CalculateTotalRentalRevenue()
    {
        return rentals.Sum(r => r.TotalCost);
    }
}

class Program
{
    static void Main()
    {
        RentalManager manager = new RentalManager();

        manager.AddCar("RJ01AA1111", "Toyota", "Camry", "Sedan", 3000);
        manager.AddCar("RJ01BB2222", "Mahindra", "XUV700", "SUV", 4500);
        manager.AddCar("RJ01CC3333", "Maruti", "Eeco", "Van", 2500);

        Console.WriteLine(manager.RentCar("RJ01AA1111", "Rahul", DateTime.Now, 3));
        Console.WriteLine(manager.RentCar("RJ01BB2222", "Priya", DateTime.Now.AddDays(1), 2));

        var grouped = manager.GroupCarsByType();
        foreach (var type in grouped)
        {
            Console.WriteLine(type.Key);
            foreach (var car in type.Value)
            {
                Console.WriteLine(car.LicensePlate);
            }
        }

        var active = manager.GetActiveRentals();
        foreach (var rental in active)
        {
            Console.WriteLine($"{rental.CustomerName} - {rental.LicensePlate}");
        }

        Console.WriteLine(manager.CalculateTotalRentalRevenue());
    }
}
