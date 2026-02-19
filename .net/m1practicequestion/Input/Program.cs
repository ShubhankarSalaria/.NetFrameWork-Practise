using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        // question 1
        string q1 = "42";
        if (int.TryParse(q1, out int age))
            Console.WriteLine("Input 1 : " + age);
        else
            Console.WriteLine("Invalid");


        // question 2
        string q2 = "12.34";
        if (double.TryParse(q2, out double db))
        {
            double rounded = Math.Round(db, 2);
            Console.WriteLine("Double : " + rounded);
        }
        else
            Console.WriteLine("Invalid input");


        // question 3
        string q3 = "1 2 3 4";
        string[] s1 = q3.Split(' ');

        foreach (string s in s1)
            Console.WriteLine(int.Parse(s));


        // question 4
        string q4 = "9.5 8.3 7.1";
        string[] s2 = q4.Split(' ');

        foreach (string s in s2)
            Console.WriteLine(double.Parse(s));


        // question 5
        string q5 = "Fifty";
        if (!int.TryParse(q5, out _))
            Console.WriteLine("Not a number");


        // question 6 
        string q6 = "15.7abc";
        StringBuilder sb = new StringBuilder();

        foreach (char ch in q6)
            if (char.IsDigit(ch) || ch == '.')
                sb.Append(ch);

        double num6 = double.Parse(sb.ToString());
        Console.WriteLine("Extracted number : " + num6);


        // question 7 
        string q7 = "999999999";
        if (long.TryParse(q7, out long a7))
            Console.WriteLine("String to long : " + a7);


        // question 8 
        string q8 = "0xFF";
        int a8 = Convert.ToInt32(q8.Replace("0x", ""), 16);
        Console.WriteLine("Hex to int : " + a8);


        // question 9
        string q9 = "42.5 36.1 -12";
        string[] arrq9 = q9.Split(' ');

        foreach (string s in arrq9)
            Console.WriteLine(double.Parse(s));


        // question 10 
        string q10 = "3E+3";
        double a10 = double.Parse(q10);
        Console.WriteLine("Scientific to double : " + a10);


        // question 11 
        string q11 = " 75 ";
        int a11 = int.Parse(q11.Trim());
        Console.WriteLine("Trimmed int : " + a11);


        // question 12 
        string q12 = "3.14.15";
        if (!double.TryParse(q12, out _))
            Console.WriteLine("Invalid number format");


        // question 13 
        string q13 = "1.000.000";
        long a13 = long.Parse(q13.Replace(".", ""));
        Console.WriteLine("Formatted long : " + a13);


        // question 14 
        string q14 = "1,234.56";
        double a14 = double.Parse(q14.Replace(",", ""));
        Console.WriteLine("Comma formatted double : " + a14);


        // question 15 
        string q15 = "(123)";
        int a15;
        if (q15.EndsWith("(") && q15.StartsWith(")"))
        {
            q15.Trim('(',')');
            if(!int.TryParse(q15,out a15))
            {
                Console.WriteLine("Invalid");
            }
        }

        int a15 = -int.Parse(q15.Trim('(', ')'));
        Console.WriteLine("Negative number : " + a15);
        StringBuilder sb = new StringBuilder();
        
        // question 16 
        string q16 = "12:30";
        string[] time = q16.Split(':');

        int totalMinutes = int.Parse(time[0]) * 60 + int.Parse(time[1]);
        Console.WriteLine("Total minutes : " + totalMinutes);


        // question 17 
        string q17 = "$1,500.75";
        string clean17 = q17.Replace("$", "").Replace(",", "");
        double a17 = double.Parse(clean17);
        Console.WriteLine("Currency value : " + a17);


        // question 18 
        string q18 = "8 16 32 bits";
        var nums18 = Regex.Matches(q18, @"\d+");

        int sum18 = 0;
        foreach (Match m in nums18)
            sum18 += int.Parse(m.Value);

        Console.WriteLine("Sum : " + sum18);


        // question 19 
        string q19 = "0b1011";
        int a19 = Convert.ToInt32(q19.Replace("0b", ""), 2);
        Console.WriteLine("Binary to int : " + a19);


        // question 20 
        string q20 = "2,000 apples and 3,500 oranges";

        var nums20 = Regex.Matches(q20, @"[\d,]+");

        int sum20 = 0;
        foreach (Match m in nums20)
        {
            string clean = m.Value.Replace(",", "");
            sum20 += int.Parse(clean);
        }

        Console.WriteLine("Total fruits : " + sum20);
    }
}
