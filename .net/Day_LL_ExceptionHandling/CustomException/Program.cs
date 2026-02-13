
public class LimitCheckerException : Exception
{
    public LimitCheckerException(string message) : base(message)
    {
        
    }
}
public class LoginSystem{
    public static void Main()
    {
        int attempts =0 ; 
        string correctPassword = "admin123";
        string inputPass = "";
        try
        {
            while (attempts < 3)
            {
                Console.WriteLine("Enter the password :");
                inputPass=Console.ReadLine();
                if (inputPass == correctPassword)
                {
                    Console.WriteLine($"input password is matched after {attempts} attempt");
                    return;
                }
                else
                {
                    Console.WriteLine("Sorry not logged in ");
                    attempts++;
                }
            }
            throw new LimitCheckerException();
        }
        catch(LimitCheckerException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Appilication terminated");
        }
    }
}