// ATM.cs
// Simulates nested-if ATM withdrawal checks.
using System;

public class ATM
{
    public string AttemptWithdrawal(bool cardInserted, bool pinValid, double balance, double amount)
    {
        if (!cardInserted)
        {
            return "Please insert your card.";
        }
        else
        {
            if (!pinValid)
            {
                return "Invalid PIN.";
            }
            else
            {
                if (amount <= 0) return "Invalid withdrawal amount.";
                if (balance >= amount)
                {
                    double newBal = balance - amount;
                    return "Please collect cash. New balance: " + newBal;
                }
                else
                {
                    return "Insufficient balance.";
                }
            }
        }
    }
}
