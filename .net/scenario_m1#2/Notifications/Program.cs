public interface INotifier
{
    public void Send(string message);
}

public class EmailNotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email : "+message);
    }
}

public class SmsNotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Smsnotifier : "+message);
    }
}
public class WhatsAppNotifier
{
    public void Send(string message)
    {
        Console.WriteLine("WhatsApp :"+message);
    }
}

public class Progra
{
    public static void Main()
    {
        List<INotifier>notification = new List<INotifier>()
        {
            new EmailNotifier(),
            new SmsNotifier(),
            new WhatsAppNotifier()
        };

        Console.WriteLine("Enter the message to send");
        string message = Console.ReadLine();

        foreach (var notify in notification)
        {
            notify.Send(message);
        }
    }
}