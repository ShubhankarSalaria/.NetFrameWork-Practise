public class EcommerceShop
{
    public string UserName{get; set;}
    public double WalletBalance{get; set;}
    public double TotalPurchaseAmount{get; set;}
}
public class InsufficientWalletBalanceException : Exception
{
    public insufficientWalletBalanceException(string message) : base(message)
    {
        
    }
}
class Program
{
    public EcommerceShop MakePayment(string name, double balance , double amount)
    {
        EcommerceShop ecom1 = new EcommerceShop
        {
          UserName=name,
          WalletBalance=balance,
          TotalPurchaseAmount=amount
        };
        
         if (balance < amount)
        {
            throw new insufficientWalletBalanceException("insufficient balance in your digital wallet");
        }
        else
        {
            ecom1.WalletBalance=-amount;
            return ecom1;
        }
    }

    public static void Main(string []args)
    {
        Program pr = new Program();
        try
        {
            EcommerceShop ecsh1 = pr.MakePayment("anshu",234,232);
            Console.WriteLine(ecsh1.UserName);
            EcommerceShop ecsh = pr.MakePayment("SHUBHANKAR",234,235);
            EcommerceShop ecsh2 = pr.MakePayment("anshuji",234,232);
            Console.WriteLine(ecsh2.UserName);
        }
        catch (insufficientWalletBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}