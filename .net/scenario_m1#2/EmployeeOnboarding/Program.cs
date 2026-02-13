using System.Data.Common;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Employee{
    public int EmpId{get; set;}  
    public string Name{get; set;}=string.Empty; 
    public string Email{get; set;}
    public int Salary{get; set;}

    public Employee(int empId , string name , string email,int salary){
        EmpId=empId;
        Name=name;
        Salary=salary<=0?30000:salary;
        Email=!email.Contains("@")?"unknown@company.com":email;
    }

    public void Display()
    {
        Console.WriteLine($"Id: {EmpId}, Name: {Name}, Email: {Email}, Salary: {Salary}");
    }
}
public class Program
{
    public static void Main()
    {
        Employee emp1 = new Employee(1, "Alice", "alicecompany.com", -5000);
        Employee emp2 = new Employee(2, "Bob", "bob@company.com", 45000);
        Employee emp3 = new Employee(3, "Charlie", "charlie.com", 0);

        emp1.Display();
        emp2.Display();
        emp3.Display();

    }
}