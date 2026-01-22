

using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();
        // full property
        p1.Name="Shubhankar";
        // validation
        p1.Age=10;
        // read only 
        Console.WriteLine(p1.RollNo);
        Password ps = new Password();
        ps.Pass="honkers";
    }
}