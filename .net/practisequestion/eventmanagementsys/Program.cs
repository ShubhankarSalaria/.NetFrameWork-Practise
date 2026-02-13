using System;
using System.Collections.Generic;
using System.Linq;

public class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; }
    public string EventType { get; set; }
    public DateTime EventDate { get; set; }
    public string Venue { get; set; }
    public int TotalCapacity { get; set; }
    public int TicketsSold { get; set; }
    public double TicketPrice { get; set; }
}

public class Attendee
{
    public int AttendeeId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<int> RegisteredEvents { get; set; } = new List<int>();
}

public class Ticket
{
    public string TicketNumber { get; set; }
    public int EventId { get; set; }
    public int AttendeeId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string SeatNumber { get; set; }
}

public class EventManager
{
    private List<Event> events = new List<Event>();
    private List<Attendee> attendees = new List<Attendee>();
    private List<Ticket> tickets = new List<Ticket>();

    private int eventCounter = 1;
    private int attendeeCounter = 1;
    private int ticketCounter = 1;

    public void CreateEvent(string name, string type, DateTime date,
                           string venue, int capacity, double price)
    {
        events.Add(new Event
        {
            EventId = eventCounter++,
            EventName = name,
            EventType = type,
            EventDate = date,
            Venue = venue,
            TotalCapacity = capacity,
            TicketsSold = 0,
            TicketPrice = price
        });
    }

    public int AddAttendee(string name, string email, string phone)
    {
        var attendee = new Attendee
        {
            AttendeeId = attendeeCounter++,
            Name = name,
            Email = email,
            Phone = phone
        };

        attendees.Add(attendee);
        return attendee.AttendeeId;
    }

    public bool BookTicket(int eventId, int attendeeId, string seatNumber)
    {
        var ev = events.FirstOrDefault(e => e.EventId == eventId);
        var attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);

        if (ev == null || attendee == null || ev.TicketsSold >= ev.TotalCapacity)
            return false;

        tickets.Add(new Ticket
        {
            TicketNumber = "T" + ticketCounter++,
            EventId = eventId,
            AttendeeId = attendeeId,
            PurchaseDate = DateTime.Now,
            SeatNumber = seatNumber
        });

        ev.TicketsSold++;
        attendee.RegisteredEvents.Add(eventId);

        return true;
    }

    public Dictionary<string, List<Event>> GroupEventsByType()
    {
        return events
            .GroupBy(e => e.EventType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Event> GetUpcomingEvents(int days)
    {
        DateTime limit = DateTime.Now.AddDays(days);
        return events
            .Where(e => e.EventDate >= DateTime.Now && e.EventDate <= limit)
            .ToList();
    }

    public double CalculateEventRevenue(int eventId)
    {
        var ev = events.FirstOrDefault(e => e.EventId == eventId);
        if (ev == null) return 0;

        return ev.TicketsSold * ev.TicketPrice;
    }

    public List<Event> GetAllEvents()
    {
        return events;
    }
}

public class Program
{
    public static void Main()
    {
        EventManager manager = new EventManager();

        manager.CreateEvent("Rock Concert", "Concert",
            DateTime.Now.AddDays(5), "Stadium", 100, 2000);

        manager.CreateEvent("Tech Conference", "Conference",
            DateTime.Now.AddDays(10), "Convention Center", 200, 3500);

        int attendee1 = manager.AddAttendee("Shubhankar", "s@email.com", "9999999999");
        int attendee2 = manager.AddAttendee("Rahul", "r@email.com", "8888888888");

        manager.BookTicket(1, attendee1, "A1");
        manager.BookTicket(1, attendee2, "A2");

        Console.WriteLine("Events Grouped By Type:");
        var grouped = manager.GroupEventsByType();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var ev in group.Value)
            {
                Console.WriteLine($"{ev.EventName} - Tickets Sold: {ev.TicketsSold}");
            }
        }

        Console.WriteLine("\nUpcoming Events (Next 7 Days):");
        foreach (var ev in manager.GetUpcomingEvents(7))
        {
            Console.WriteLine(ev.EventName);
        }

        Console.WriteLine("\nRevenue For Event 1:");
        Console.WriteLine(manager.CalculateEventRevenue(1));
    }
}
