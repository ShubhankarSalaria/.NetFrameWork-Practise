
public class Student
{
    public string? Name {get; set;}
    public int Mark1 {get; set;}
    public int Mark2 {get; set;}

}

public class Program
{
    public delegate void Notification();

    public static double avgNum(int a , int b){
            return (a+b)/2.0;
    }
    public static void Improve()
    {
        Console.WriteLine("need improvement");
    }
    public static void AvgStu()
    {
        Console.WriteLine("averge student");
    }

    public static void goodStu()
    {
        Console.WriteLine("Good Student");
    }

    public static void Main(string[] args)
    {
        Notification notify = Improve;
        List<Student> students= new List<Student>();
        char choice ='y';
        while (char.ToLower(choice) == 'y')
        {
            Student s = new Student();
            Console.WriteLine("Enter the student name :");
            s.Name=Console.ReadLine();
            
            Console.WriteLine("Enter mark 1 :");
            s.Mark1=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter mark 2 :");
            s.Mark2=int.Parse(Console.ReadLine());
            double avg= avgNum(s.Mark1, s.Mark2);
            students.Add(s);
            if (avg<40)
            {
                notify=Improve;
            }
            else if (avg < 80)
            {
                notify=AvgStu;
            }
            else if(avg <= 100){
                notify=goodStu;
            }
            notify();
            Console.WriteLine("want to add other the student (y/n) :");
            choice=Console.ReadLine()[0];
            Console.WriteLine("-----------------------");
          }
        Console.WriteLine("\n Student Summary:");
        foreach (var s in students)
        {
            double avg = avgNum(s.Mark1, s.Mark2);
            Console.WriteLine($"Name: {s.Name}, Marks: {s.Mark1}:{s.Mark2}, Avg: {avg:F2}");
        }

        Console.WriteLine("\nProgram Ended.");
    }
}