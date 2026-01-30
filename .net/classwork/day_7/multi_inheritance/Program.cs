// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace birds;

/// <summary>
/// fly method declare here 
/// </summary>
interface IFly
{
    void fly();
}

/// <summary>
/// ISing interface with sing methods 
/// </summary>
interface ISing
{
    void Sing();
}

/// <summary>
/// duck class is inheriting
/// </summary>
class Duck: IFly , ISing
{
    public void fly()
    {
        Console.WriteLine("Duck can fly");
    }
    public void Sing()
    {
        Console.WriteLine("Duck can Sing");
    }
}

/// <summary>
/// main method is here 
/// </summary>
public class Program
{
    public static void  Main(String[] args)
    {
        Duck d1 = new Duck();
        d1.fly();
        d1.Sing();
    }
}
