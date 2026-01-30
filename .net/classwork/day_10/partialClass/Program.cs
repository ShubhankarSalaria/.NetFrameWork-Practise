// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        Calc obj= new Calc();
        Console.WriteLine("calc after the addition: "+obj.add(34,23));
        Console.WriteLine("partial calc after the multiply: "+obj.multiply(43,67));
    }
}