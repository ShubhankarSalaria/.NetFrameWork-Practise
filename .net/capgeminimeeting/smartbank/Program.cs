using System;

public class InvalidCreditDataException : Exception
{
    public InvalidCreditDataException(string message) : base(message)
    {
    }
}

public class CreditRiskProcessor
{
    public bool validateCustomerDetails(int age, string employmentType,
        double monthlyIncome, double dues, int creditScore, int defaults)
    {
        if (age < 21 || age > 65)
            throw new InvalidCreditDataException("Age is invalid");

        if (employmentType != "Salaried" && employmentType != "Self-Employed")
            throw new InvalidCreditDataException("Invalid employment type");

        if (monthlyIncome < 20000)
            throw new InvalidCreditDataException("Invalid monthly income");

        if (dues < 0)
            throw new InvalidCreditDataException("Invalid credit dues");

        if (creditScore < 300 || creditScore > 900)
            throw new InvalidCreditDataException("Invalid credit score");

        if (defaults < 0)
            throw new InvalidCreditDataException("Invalid default count");

        return true;
    }

    public int calculateCreditLimit(double monthlyIncome, double dues,
        int creditScore, int defaults)
    {
        double debtRatio = dues / (monthlyIncome * 12);

        if (creditScore < 600 || defaults >= 3 || debtRatio >= 0.4)
            return 50000;

        else if ((creditScore >= 600 && creditScore <= 749) ||
                 defaults == 1 || debtRatio < 0.4)
            return 150000;

        else if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            return 300000;

        return 50000; 
    }
}

public class UserInterface
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employment type: ");
            string type = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double monthlyIncome = double.Parse(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double creditDues = double.Parse(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine());

            CreditRiskProcessor utility = new CreditRiskProcessor();

            utility.validateCustomerDetails(age, type, monthlyIncome,
                creditDues, creditScore, defaults);

            int creditLimit = utility.calculateCreditLimit(monthlyIncome,
                creditDues, creditScore, defaults);

            Console.WriteLine($"\nCustomer Name: {name}");
            Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
