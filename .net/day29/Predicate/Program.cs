using System.Runtime.CompilerServices;

public class Program
{
    public static void Main()
    {
        // is the number even or not 
        Predicate<int> isEven = n => n%2 == 0;
        Console.WriteLine($"Number is even :{isEven(4)}");
        Console.WriteLine($"Number is even :{isEven(5)}");

        // will the student pass or fail
        Predicate<int> isPass = n => n>=40;
        Console.WriteLine($"Number is {isPass(39)}");
        Console.WriteLine($"Number is {isPass(40)}");

        var marks = new List<int> {12,45,78,35,90};
    }
}