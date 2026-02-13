using System;
using System.Collections.Generic;
using System.Linq;

public class Flight
{
    public string FlightNumber { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public double TicketPrice { get; set; }
}

public class Booking
{
    public string BookingId { get; set; }
    public string FlightNumber { get; set; }
    public string PassengerName { get; set; }
    public int SeatsBooked { get; set; }
    public double TotalFare { get; set; }
    public string SeatClass { get; set; }
}

public class AirlineManager
{
    private List<Flight> flights = new List<Flight>();
    private List<Booking> bookings = new List<Booking>();
    private int bookingCounter = 1;

    public void AddFlight(string number, string origin, string destination,
                         DateTime depart, DateTime arrive, int seats, double price)
    {
        flights.Add(new Flight
        {
            FlightNumber = number,
            Origin = origin,
            Destination = destination,
            DepartureTime = depart,
            ArrivalTime = arrive,
            TotalSeats = seats,
            AvailableSeats = seats,
            TicketPrice = price
        });
    }

    public bool BookFlight(string flightNumber, string passenger,
                           int seats, string seatClass)
    {
        var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null || seats <= 0 || flight.AvailableSeats < seats)
            return false;

        double multiplier = seatClass == "Business" ? 1.5 : 1.0;
        double totalFare = seats * flight.TicketPrice * multiplier;

        bookings.Add(new Booking
        {
            BookingId = "B" + bookingCounter++,
            FlightNumber = flightNumber,
            PassengerName = passenger,
            SeatsBooked = seats,
            TotalFare = totalFare,
            SeatClass = seatClass
        });

        flight.AvailableSeats -= seats;
        return true;
    }

    public Dictionary<string, List<Flight>> GroupFlightsByDestination()
    {
        return flights
            .GroupBy(f => f.Destination)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Flight> SearchFlights(string origin, string destination, DateTime date)
    {
        return flights.Where(f =>
            f.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
            f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
            f.DepartureTime.Date == date.Date).ToList();
    }

    public double CalculateTotalRevenue(string flightNumber)
    {
        return bookings
            .Where(b => b.FlightNumber == flightNumber)
            .Sum(b => b.TotalFare);
    }

    public List<Flight> GetAllFlights()
    {
        return flights;
    }
}

public class Program
{
    public static void Main()
    {
        AirlineManager manager = new AirlineManager();

        manager.AddFlight("AI101", "Delhi", "Mumbai",
            DateTime.Now.AddHours(5), DateTime.Now.AddHours(7), 150, 5000);

        manager.AddFlight("AI102", "Delhi", "Bangalore",
            DateTime.Now.AddHours(6), DateTime.Now.AddHours(9), 120, 6000);

        manager.BookFlight("AI101", "Shubhankar", 2, "Economy");
        manager.BookFlight("AI101", "Rahul", 1, "Business");

        Console.WriteLine("Flights To Mumbai:");
        var grouped = manager.GroupFlightsByDestination();
        foreach (var flight in grouped["Mumbai"])
        {
            Console.WriteLine($"{flight.FlightNumber} Seats Left: {flight.AvailableSeats}");
        }

        Console.WriteLine("\nSearch Delhi -> Mumbai:");
        var search = manager.SearchFlights("Delhi", "Mumbai", DateTime.Now);
        foreach (var f in search)
        {
            Console.WriteLine($"{f.FlightNumber} Departure: {f.DepartureTime}");
        }

        Console.WriteLine("\nRevenue for AI101:");
        Console.WriteLine(manager.CalculateTotalRevenue("AI101"));
    }
}
