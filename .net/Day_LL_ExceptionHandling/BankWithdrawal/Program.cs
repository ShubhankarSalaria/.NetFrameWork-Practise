using System;
using System.Linq.Expressions;

public class BankAccount
{
    static void Main()
    {
        int balance= 10000;
        Console.WriteLine("Enter withdrawal amount : ");
        int amount = int.Parse(Console.ReadLine());
        try
        {
            if(amount <=0 )
            {
            throw new ArgumentException("amount cant be negative");
            }
            else if(amount > balance)
            {
            throw new ArgumentException("amount is greater then balance");
            }
            else
            {
                balance-=amount;
                Console.WriteLine($"balance is {balance}");
            }
        } 
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("transaction is completed");
        }
    }
}