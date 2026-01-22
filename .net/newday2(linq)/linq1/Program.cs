using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;
class student
{
    public string ? Name {get; set;}
    public int RollNo{get; set;}

    public int Mark1 {get; set;}
    public int Mark2 {get; set;}
}
class LinqStudent
{
    public string? Name {get; set;}
}
class MyProcess
{
    public int Id{get; set;}
    public string? Name {get; set;}
}
class Program
{
    private static void LinqExample2()
    {
        var proCollection = from p in System.Diagnostics.Process.GetProcesses()
                                select new MyProcess(){Name = p.ProcessName , Id=p.Id};
        foreach (var proc in proCollection)
        {
            Console.WriteLine($"Process name = {proc.Name} id = {proc.Id}");
        }
    }
    private static void LinqExammpleStu()
    {
        List<student> students = new List<student>
        {
            new student {RollNo=1,Name="Sam",Mark1=23,Mark2=34},
            new student {RollNo=2,Name="Pam",Mark1=45,Mark2=34}
        };
        var  classAverage = from stu in students 
                                select new {Id = stu.RollNo , Name = stu.Name , Average=(stu.Mark1+stu.Mark2)/2};
        foreach(var n in classAverage)
        {
            Console.WriteLine(n.Average);
        }
    }
    public static void Main(String[] args)
    {
        string [] name = {"aba","bvv","cdd"};
        foreach(var i in name)
        {
            if (i == "b")
            {
                Console.WriteLine("b is present");
                break;
            }
        }
        var findName = from nam in name 
                        where nam=="b" 
                        select nam ;
        if(findName != null)
        {
            Console.WriteLine("we found the b here");
        }

        // bulk operation 
        var findName2 = from nam in name 
                        //where nam=="b" 
                        orderby nam ascending 
                        select nam.ToUpper() ;
        foreach(var n in findName2)
        {
            Console.WriteLine(n);
        }

        var findName3 = from nam in name 
                        //where nam=="b" 
                        orderby nam ascending 
                        select isPalindrome(nam) ;
        foreach(var n in findName3)
        {
            Console.WriteLine(n);
        }

        var findName4 = from nam in name 
                        //where nam=="b" 
                        orderby nam ascending 
                        select new LinqStudent()
                        {
                            Name=nam
                        };
        foreach(var n in findName4)
        {
            Console.WriteLine(n);
        }

        //
        Console.WriteLine("processor");
        LinqExample2();
        LinqExammpleStu();
    }
    public static  string isPalindrome(string name)
    {
        string reversed = new string(name.Reverse().ToArray());
        if (reversed == name)
        {
           return "Palindrome "+name; 
        }
        else
        {
            return "not a palindrome :"+name;
        }
    }
}