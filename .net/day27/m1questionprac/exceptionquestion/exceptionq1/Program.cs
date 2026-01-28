public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {
    }
}
public class EntryUtility
{
    
    public bool ValidateEmployeeId(string employeeId)
    {
        
        if (!Regex.IsMatch(employeeId, @"^GOAIR\/\d{4}$"))
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }

    
    public bool ValidateDuration(int duration)
    {
        if (duration < 1 || duration > 5)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }
}

public class UserInterface
{
    public static void Main()
    {
        EntryUtility utility = new EntryUtility();

        Console.WriteLine("Enter the number of entries");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter entry {i} details");
            string input = Console.ReadLine();

            try
            {
                // Format: EmployeeId:EntryType:Duration
                string[] parts = input.Split(':');

                string employeeId = parts[0];
                // Entry type is not validated as per problem
                int duration = int.Parse(parts[2]);

                // Validate
                utility.ValidateEmployeeId(employeeId);
                utility.ValidateDuration(duration);

                Console.WriteLine("Valid entry details");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry details");
            }
        }
    }
}