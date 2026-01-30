// See https://aka.ms/new-console-template for more information
namespace interface1;


/// <summary>
/// interface is pure abstraact only mehod without body 
/// </summary>
interface Iprint
{
    public void print();
}

/// <summary>
/// now inheret the interface and implement the 
/// </summary>
class child : Iprint
{
    public void Print()
    {
        Console.WriteLine("printed from the child class");
    }
}
