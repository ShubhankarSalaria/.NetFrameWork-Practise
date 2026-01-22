// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

class Person
{
    public string Name {get; set;}
    public string Address {get; set;} 
    public  int Age {get; set;}
    
}
class PersonImplementation
{
    public string GetName(IList<Person> person)
    {
        string AllPerson="";
        foreach(var prn  in person)
        {
            AllPerson+=$"{prn.Name} {prn.Address} ";
        }
        return AllPerson;
    }
    public double Average(IList<Person> person)
    {
        double sum =0;
        int count = 0;
        foreach (var prn in person)
        {
            sum+=prn.Age;
            count++;
        }
        return (sum/count);
    }
    public int Max(IList<Person> person)
    {
        int max = int.MinValue;
        foreach(var prn in person)
        {
            max = max>prn.Age?max:prn.Age;
        }
        return max;
    }
}

class Program
{
    public static void Main()
    {
        IList<Person> p = new List<Person>();
        p.Add(new Person {Name = "Aarya" , Address="A2101" , Age = 69});
        p.Add(new Person {Name = "Daniel" , Address="A2102" , Age = 40});
        p.Add(new Person {Name = "Ira" , Address="A2145" , Age = 25});
        p.Add(new Person {Name = "Jennifer" , Address="I1704" , Age = 33});

        PersonImplementation PIMP =  new PersonImplementation();
        Console.WriteLine(PIMP.GetName(p));
        Console.WriteLine(PIMP.Average(p));
        Console.WriteLine(PIMP.Max(p));
    }
}