public class BankAccount
{
    private int balance =0;

    // Deposit method
    public void Deposit(double amount) {
        if (amount > 0) {
            balance += amount;
        }
    }

    // Withdraw method
    public void Withdraw(double amount) {
        if (amount > 0 && amount <= balance) {
            balance -= amount;
        }
    }

    // Method to get balance
    public double getBalance() {
        return balance;
    }

}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        for (int i = 0; i < 5; i++)
        {
            string input = Console.ReadLine();   // Example: D 500
            string[] parts = input.Split(' ');

            char type = char.Parse(parts[0]);
            double amount = double.Parse(parts[1]);

            if (type == 'D' || type == 'd')
                account.Deposit(amount);
            else if (type == 'W' || type == 'w')
                account.Withdraw(amount);
        }

        Console.WriteLine("Final Balance: " + account.GetBalance());
    }
}