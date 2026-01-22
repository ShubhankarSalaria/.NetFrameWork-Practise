class User
{
    public string Name {get; set;}
    public string Password {get; set;}
    public string ConfirmationPassword {get; set;}
}

class PasswordMismatchException : Exception
{
    public PasswordMismatchException(string message) : base (message)
    {
        
    }
}
class Program
{
    public User ValidatePassword(string name , string password , string confirmationPassword)
    {
        User user1 = new User
        {
            Name = name,
            Password=password,
            ConfirmationPassword=confirmationPassword,
        };
        
            if (!password.Equals(confirmationPassword))
            {
                throw new PasswordMismatchException("Password and confirmation password do not match");
            }
        return user1;
        
    }
    public static void Main(string[] args)
    {
        Program pr = new Program();
        try
        {
             // INPUT SECTION
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Confirm password: ");
            string confirmPassword = Console.ReadLine();

            // METHOD CALL
            User user = pr.ValidatePassword(name, password, confirmPassword);

            Console.WriteLine("User created successfully!");
            Console.WriteLine("Welcome " + user.Name);
            
        }
        catch (PasswordMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }   
        
    }
}