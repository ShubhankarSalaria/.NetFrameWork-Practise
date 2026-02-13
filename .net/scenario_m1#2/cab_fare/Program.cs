using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using System.Xml.Serialization;

public class Cab
{
    public int fare {get; set;}

    public virtual void CalculateFare(int km)
    {
        fare = km*12;
    }

}

public class Mini : Cab
{
    public override void CalculateFare(int km)
    {
        fare=km*12;
    }
}

public class Sedan : Cab
{
    public override void CalculateFare(int km)
    {
        fare=km*15+50;
    }
}
public class Suv : Cab
{
    public override void CalculateFare(int km)
    {
        fare=km*18+100;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the type and km :");
        string input = Console.ReadLine();
        string []part = input.Split(" ");
        int km= Convert.ToInt32(part[1]);
        if (part[0] == "Suv")
        {
            Cab suv = new Suv();
            suv.CalculateFare(km);
            Console.WriteLine(suv.fare);
        }
        else if (part[0] == "Sedan")
        {
            Cab sedan = new Sedan();
            sedan.CalculateFare(km);
            Console.WriteLine(sedan.fare);
        }
        else if (part[0] == "Mini")
        {
            Cab mini = new Mini();
            mini.CalculateFare(km);
            Console.WriteLine(mini.fare);
        }
        else
        {
            Console.WriteLine("Enter valid input");
        }
    }
}