public class Person
{
    public int Age{get; set;}
    public string Name{get; set;}

    public Person(int age , string Name)
    {
        Age=age;
        Name=Name;
    } 
}
public class Student : Person
{
    public int RollNo {get; set;}
    public int Marks  {get; set;}

    public Student(int age, string name , int rollno , int marks):base(age , name)
    {
        RollNo=rollno;
        Marks=marks; 
    }
}

public class Program
{
    public static void Main()
    {
        Student stu = new Student()
        {
            Name ="Shubhankar",
            Age = 35,
            RollNo = 1,
            Marks = 34
        };
        if (stu.Marks < 35)
        {
            Console.WriteLine("Fail");
        }
        else
        {
            Console.WriteLine("Pass");
        }
    }
}