class Program
{
    public static List<int> NumberList = new List<int>();

    public void AddfNummbers(int Numbers)
    {
        NumberList.Add(Numbers);
    }

    public double GetGPAScored()
    {
        double sum = 0;
        foreach (var num in NumberList)
        {
            sum += num * 3;
        }
        return (sum / (NumberList.Count * 3));
    }

    public char GetGradeScored(double gpa)
    {
        if (gpa == 10.0)
            return 'S';
        else if (gpa >= 9)
            return 'A';
        else if (gpa >= 8)
            return 'B';
        else if (gpa >= 7)
            return 'C';
        else if (gpa >= 6)
            return 'D';
        else if (gpa >= 5)
            return 'E';
        else
            return 'X'; // invalid / fail
    }

    //  STATIC MAIN FUNCTION
    public static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("Enter 4 subject marks:");

        for (int i = 1; i <= 4; i++)
        {
            Console.Write($"Enter mark {i}: ");
            int num = int.Parse(Console.ReadLine());
            p.AddfNummbers(num);
        }

        double gpa = p.GetGPAScored();
        char grade = p.GetGradeScored(gpa);

        Console.WriteLine($"\nGPA Scored: {gpa:F2}");
        Console.WriteLine($"Grade: {grade}");
    }
}