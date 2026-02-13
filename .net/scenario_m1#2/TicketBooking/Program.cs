public class Ticket
{
    private static int  LastTicketNo = 1000;
    public int TicketNumber {get; private set;}

    public Ticket()
    {
        LastTicketNo++;
        TicketNumber=LastTicketNo;
    }
}
public class Program
{
    public static void Main()
    {
        List<Ticket>tickets = new List<Ticket>();
        Console.WriteLine("enter the no  of the ticket needed :");
        int n = Convert.ToInt32(Console.ReadLine());
        for( int i =0 ; i< n ; i++)
        {
            tickets.Add(new Ticket());
        }
        foreach ( var tick in tickets)
        {
            Console.WriteLine(tick.TicketNumber);
        }
    }
}