public class MovieScreening
{
    public string MovieTitle { get; set; }
    public DateTime ShowTime { get; set; }
    public string ScreenNumber { get; set; }
    public int TotalSeats { get; set; }
    public int BookedSeats { get; set; }
    public double TicketPrice { get; set; }

    public MovieScreening(string title, DateTime time, string screen, int seats, double price)
    {
        MovieTitle = title;
        ShowTime = time;
        ScreenNumber = screen;
        TotalSeats = seats;
        TicketPrice = price;
        BookedSeats = 0;
    }

    // Helper Property
    public int AvailableSeats => TotalSeats - BookedSeats;
}
public class TheaterManager
{
    private List<MovieScreening> screenings = new List<MovieScreening>();

    // Add Screening
    public void AddScreening(string title, DateTime time, string screen,
                             int seats, double price)
    {
        if (seats <= 0 || price <= 0)
        {
            Console.WriteLine("Invalid seat count or ticket price.");
            return;
        }

        screenings.Add(new MovieScreening(title, time, screen, seats, price));
    }

    // Book Tickets
    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        var screening = screenings.FirstOrDefault(s =>
            s.MovieTitle.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)
            && s.ShowTime == showTime);

        if (screening == null || tickets <= 0 || screening.AvailableSeats < tickets)
            return false;

        screening.BookedSeats += tickets;
        return true;
    }

    // Group Screenings By Movie
    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        return screenings
               .GroupBy(s => s.MovieTitle)
               .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Calculate Total Revenue
    public double CalculateTotalRevenue()
    {
        return screenings.Sum(s => s.BookedSeats * s.TicketPrice);
    }

    // Get Screenings with Minimum Available Seats
    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        return screenings
               .Where(s => s.AvailableSeats >= minSeats)
               .ToList();
    }
}

class Program
{
    static void Main()
    {
        TheaterManager theater = new TheaterManager();

        // 1️ Add Screenings
        theater.AddScreening("Avengers", DateTime.Parse("2026-02-10 18:00"), "Screen 1", 100, 250);
        theater.AddScreening("Avengers", DateTime.Parse("2026-02-10 21:00"), "Screen 2", 80, 250);
        theater.AddScreening("Inception", DateTime.Parse("2026-02-10 19:00"), "Screen 3", 90, 200);

        // 2️ Book Tickets
        Console.WriteLine("Booking Tickets...");
        bool booked = theater.BookTickets("Avengers", DateTime.Parse("2026-02-10 18:00"), 5);
        Console.WriteLine(booked ? "Booking Successful" : "Booking Failed");

        // 3️ Display Screenings By Movie
        Console.WriteLine("\nScreenings By Movie:");
        var grouped = theater.GroupScreeningsByMovie();

        foreach (var movie in grouped)
        {
            Console.WriteLine($"\nMovie: {movie.Key}");
            foreach (var show in movie.Value)
            {
                Console.WriteLine($"{show.ShowTime} - {show.ScreenNumber} - Available: {show.AvailableSeats}");
            }
        }

        // 4️ Check Available Screenings for Group Booking
        Console.WriteLine("\nScreenings with at least 50 seats:");
        var available = theater.GetAvailableScreenings(50);

        foreach (var show in available)
        {
            Console.WriteLine($"{show.MovieTitle} - {show.ShowTime} - Seats Left: {show.AvailableSeats}");
        }

        // 5️ Revenue Tracking
        Console.WriteLine("\nTotal Revenue: ₹" + theater.CalculateTotalRevenue());
    }
}