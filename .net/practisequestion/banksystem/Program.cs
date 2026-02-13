using System;
using System.Collections.Generic;
using System.Linq;

public class Transaction
{
    public string TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
}

public class Account
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string AccountType { get; set; }
    public double Balance { get; set; }
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
}

public class BankManager
{
    private List<Account> accounts = new List<Account>();
    private int accountCounter = 1000;
    private int transactionCounter = 1;

    public void CreateAccount(string holder, string type, double initialDeposit)
    {
        var account = new Account
        {
            AccountNumber = "ACC" + accountCounter++,
            AccountHolder = holder,
            AccountType = type,
            Balance = initialDeposit
        };

        if (initialDeposit > 0)
        {
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "T" + transactionCounter++,
                TransactionDate = DateTime.Now,
                Type = "Deposit",
                Amount = initialDeposit,
                Description = "Initial Deposit"
            });
        }

        accounts.Add(account);
    }

    public bool Deposit(string accountNumber, double amount)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null || amount <= 0) return false;

        account.Balance += amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = "T" + transactionCounter++,
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = amount,
            Description = "Deposit"
        });

        return true;
    }

    public bool Withdraw(string accountNumber, double amount)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null || amount <= 0 || account.Balance < amount) return false;

        account.Balance -= amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = "T" + transactionCounter++,
            TransactionDate = DateTime.Now,
            Type = "Withdrawal",
            Amount = amount,
            Description = "Withdrawal"
        });

        return true;
    }

    public Dictionary<string, List<Account>> GroupAccountsByType()
    {
        return accounts
            .GroupBy(a => a.AccountType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null) return new List<Transaction>();

        return account.TransactionHistory
            .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
            .ToList();
    }

    public List<Account> GetAllAccounts()
    {
        return accounts;
    }
}

public class Program
{
    public static void Main()
    {
        BankManager bank = new BankManager();

        bank.CreateAccount("Shubhankar", "Savings", 5000);
        bank.CreateAccount("Rahul", "Current", 10000);

        var accounts = bank.GetAllAccounts();
        string acc1 = accounts[0].AccountNumber;

        bank.Deposit(acc1, 2000);
        bank.Withdraw(acc1, 1000);

        var grouped = bank.GroupAccountsByType();

        Console.WriteLine("Accounts Grouped By Type:");
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var acc in group.Value)
            {
                Console.WriteLine(acc.AccountHolder + " - " + acc.AccountNumber + " - Balance: " + acc.Balance);
            }
        }

        Console.WriteLine("\nStatement:");
        var statement = bank.GetAccountStatement(acc1, DateTime.Now.AddDays(-1), DateTime.Now);

        foreach (var txn in statement)
        {
            Console.WriteLine(txn.TransactionDate + " - " + txn.Type + " - " + txn.Amount);
        }
    }
}
