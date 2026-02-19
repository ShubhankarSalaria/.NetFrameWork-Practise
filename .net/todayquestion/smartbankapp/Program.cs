using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exceptions

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message) { }
}

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message) { }
}

#endregion

#region Abstract Class

public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; protected set; }

    public List<string> TransactionHistory { get; set; } = new List<string>();

    protected BankAccount(string accNo, string name, decimal balance)
    {
        AccountNumber = accNo;
        CustomerName = name;
        Balance = balance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Deposit amount must be positive.");

        Balance += amount;
        TransactionHistory.Add($"Deposited: {amount}");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Withdrawal amount must be positive.");

        if (amount > Balance)
            throw new InsufficientBalanceException("Insufficient balance.");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public void Transfer(BankAccount toAccount, decimal amount)
    {
        this.Withdraw(amount);
        toAccount.Deposit(amount);
        TransactionHistory.Add($"Transferred {amount} to {toAccount.AccountNumber}");
    }

    public abstract void CalculateInterest();

    public override string ToString()
    {
        return $"{AccountNumber} - {CustomerName} - Balance: {Balance}";
    }
}

#endregion

#region Derived Classesde

public class SavingsAccount : BankAccount
{
    private const decimal MinimumBalance = 1000;

    public SavingsAccount(string accNo, string name, decimal balance)
        : base(accNo, name, balance)
    {
        if (balance < MinimumBalance)
            throw new MinimumBalanceException("Savings account requires minimum balance of 1000.");
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinimumBalance)
            throw new MinimumBalanceException("Cannot go below minimum balance.");

        base.Withdraw(amount);
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * 0.04m;
        Balance += interest;
        TransactionHistory.Add($"Interest added: {interest}");
    }
}

public class CurrentAccount : BankAccount
{
    private const decimal OverdraftLimit = 5000;

    public CurrentAccount(string accNo, string name, decimal balance)
        : base(accNo, name, balance) { }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < -OverdraftLimit)
            throw new InsufficientBalanceException("Overdraft limit exceeded.");

        Balance -= amount;
        TransactionHistory.Add($"Withdrawn: {amount}");
    }

    public override void CalculateInterest()
    {
        // No interest for current account
    }
}

public class LoanAccount : BankAccount
{
    public LoanAccount(string accNo, string name, decimal balance)
        : base(accNo, name, balance) { }

    public override void Deposit(decimal amount)
    {
        throw new InvalidTransactionException("Cannot deposit in Loan Account.");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * 0.10m;
        Balance += interest;
        TransactionHistory.Add($"Loan interest added: {interest}");
    }
}

#endregion

#region Program

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void Main()
    {
        SeedData();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Smart Banking System ---");
            Console.WriteLine("1. View All Accounts");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. LINQ Reports");
            Console.WriteLine("6. Exit");

            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        accounts.ForEach(a => Console.WriteLine(a));
                        break;

                    case 2:
                        PerformDeposit();
                        break;

                    case 3:
                        PerformWithdraw();
                        break;

                    case 4:
                        PerformTransfer();
                        break;

                    case 5:
                        RunLinqReports();
                        break;

                    case 6:
                        exit = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void SeedData()
    {
        accounts.Add(new SavingsAccount("S101", "Ravi", 60000));
        accounts.Add(new CurrentAccount("C201", "Amit", 40000));
        accounts.Add(new LoanAccount("L301", "Rohan", 80000));
        accounts.Add(new SavingsAccount("S102", "Raj", 120000));
    }

    static BankAccount FindAccount(string accNo)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accNo);
    }

    static void PerformDeposit()
    {
        Console.Write("Enter Account No: ");
        string acc = Console.ReadLine();
        Console.Write("Amount: ");
        decimal amt = Convert.ToDecimal(Console.ReadLine());

        FindAccount(acc)?.Deposit(amt);
    }

    static void PerformWithdraw()
    {
        Console.Write("Enter Account No: ");
        string acc = Console.ReadLine();
        Console.Write("Amount: ");
        decimal amt = Convert.ToDecimal(Console.ReadLine());

        FindAccount(acc)?.Withdraw(amt);
    }

    static void PerformTransfer()
    {
        Console.Write("From Account: ");
        string from = Console.ReadLine();
        Console.Write("To Account: ");
        string to = Console.ReadLine();
        Console.Write("Amount: ");
        decimal amt = Convert.ToDecimal(Console.ReadLine());

        var fromAcc = FindAccount(from);
        var toAcc = FindAccount(to);

        fromAcc?.Transfer(toAcc, amt);
    }

    static void RunLinqReports()
    {
        Console.WriteLine("\nAccounts with Balance > 50,000:");
        var highBalance = accounts.Where(a => a.Balance > 50000);
        foreach (var acc in highBalance)
            Console.WriteLine(acc);

        Console.WriteLine("\nTotal Bank Balance:");
        Console.WriteLine(accounts.Sum(a => a.Balance));

        Console.WriteLine("\nTop 3 Highest Balance Accounts:");
        var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
        foreach (var acc in top3)
            Console.WriteLine(acc);

        Console.WriteLine("\nGrouped By Account Type:");
        var grouped = accounts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var acc in group)
                Console.WriteLine("  " + acc);
        }

        Console.WriteLine("\nCustomers starting with 'R':");
        var rCustomers = accounts.Where(a => a.CustomerName.StartsWith("R"));
        foreach (var acc in rCustomers)
            Console.WriteLine(acc);
    }
}

#endregion
