using System.Runtime.InteropServices;
using System.Security;

public abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double Amount);
}
public class FestivalDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double Amount)
    {
        if (Amount >= 5000)
        {
            return Amount*0.90;
        }
        else
        {
            return Amount*0.95;
        }
    }
}

public class MemberDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double Amount)
    {
        if(Amount >= 2000)
        {
            return Amount-300;
        }
        else
        {
            return Amount;
        }
    }
}

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Enter the discount type and amount :");
        string input = Console.ReadLine();
        string []part = input.Split(" ");
        string Dtype = part[0];
        double amount= Convert.ToDouble(part[1]);
        double  finalamount=0;
        
        /// alternative method for the discountpolicy 
        /// 
        List<DiscountPolicy>policies = new List<DiscountPolicy>();
        if (Dtype.Contains("Fd"))
        {
            policies.Add(new FestivalDiscount());
        }
        if (Dtype.Contains("Md"))
        {
            policies.Add(new MemberDiscount());
        }
        double finalamount2 = amount;
        foreach( var policy in policies)
        {
            finalamount2 = policy.GetFinalAmount(finalamount2);
        }
        ///
        if (Dtype=="FdMd")
        {
            FestivalDiscount fd = new FestivalDiscount();
            MemberDiscount md = new MemberDiscount();
            finalamount=fd.GetFinalAmount(amount);
            finalamount=md.GetFinalAmount(finalamount);
        }
        else if(Dtype=="Fd")
        {
            FestivalDiscount fd = new FestivalDiscount();
            finalamount=fd.GetFinalAmount(amount);
        }
        else if (Dtype=="Md")
        {
           
            MemberDiscount md = new MemberDiscount();
            finalamount=md.GetFinalAmount(amount);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
        Console.WriteLine("the final amount is : "+finalamount);
        
    }
}