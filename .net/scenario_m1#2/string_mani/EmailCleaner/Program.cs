public class Program
{
    public static void Main()
    {
          Console.Write("Enter email: ");
        string password = Console.ReadLine();

        string CleanEmail = EmailCleaner(password);

        Console.WriteLine($"correct email: {CleanEmail}");
       
    }
    public static string EmailCleaner(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return "";
        }
        email=email.Trim();

        email=email.ToLower();

        if (email.EndsWith("@gmail.com"))
        {
            email=email.Replace("@gmail.com", "@company.com");
        }
        return email;
    }
}