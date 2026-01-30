public class Student
{
    public string? Name {get; set;}
    public int Mark1 {get; set;}
    public int Mark2 {get; set;}

}
public class Program
{
    public static void Main(string[] args)
    {
        List<Student>students=new List<Student>()
        {
            new Student { Name="Aman", Mark1=30, Mark2=35 },
            new Student { Name="Neha", Mark1=70, Mark2=80 },
            new Student { Name="Ravi", Mark1=50, Mark2=55 }
        };

        Func<Student,double> calcAvg= 
            s => (s.Mark1+s.Mark2)/2;
        Predicate<Student> needImprovement=
            s => calcAvg(s)<40;
        Action<Student> notify =
            s =>
            {
                Console.WriteLine($"{s.Name} need improvement");
            };
        foreach (var s in students)
        {
            if (needImprovement(s))
            {
                notify(s);
            }
        }
    }
}