using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Seat
{
    public int SeatNo { get; set; }
    public bool IsBooked { get; set; }
    public string BookedBy { get; set; } = string.Empty;

    // Seat level lock for better concurrency
    public object SeatLock { get; } = new object();
}

public class TicketBookingService
{
    private readonly Dictionary<int, Seat> _seats;

    public TicketBookingService(int totalSeats)
    {
        _seats = new Dictionary<int, Seat>();

        for (int i = 1; i <= totalSeats; i++)
        {
            _seats[i] = new Seat
            {
                SeatNo = i,
                IsBooked = false
            };
        }
    }

    public bool BookSeat(int seatNo, string userId)
    {
        if (!_seats.ContainsKey(seatNo))
            throw new ArgumentException("Invalid seat number");

        Seat seat = _seats[seatNo];

        // Thread-safe lock per seat
        lock (seat.SeatLock)
        {
            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            seat.BookedBy = userId;

            return true;
        }
    }

    public void DisplaySeatStatus()
    {
        foreach (var seat in _seats.Values)
        {
            Console.WriteLine(
                $"Seat {seat.SeatNo} | Booked: {seat.IsBooked} | User: {seat.BookedBy}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        TicketBookingService bookingService = new TicketBookingService(5);

        // Multiple users trying to book the same seat simultaneously
        Parallel.For(1, 6, i =>
        {
            bool result = bookingService.BookSeat(1, $"User-{i}");
            Console.WriteLine($"User-{i} booking result: {result}");
        });

        Console.WriteLine("\nFinal Seat Status:");
        bookingService.DisplaySeatStatus();
    }
}
