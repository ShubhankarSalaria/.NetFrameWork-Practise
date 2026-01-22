using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

class Source
{
    public int Add(int a , int b , int c)
    {
        Console.WriteLine("int");
        return a+b+c;
    }
    public  double Add(double a , double b , double c)
    {
        Console.WriteLine("double");
        return a+b+c;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Source sc = new Source();
        Console.WriteLine(sc.Add(2,3,4));
        Console.WriteLine(sc.Add(3.4,4.5,7.8));
    }
}