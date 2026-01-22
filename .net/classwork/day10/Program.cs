// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        string str="madam";
        Console.WriteLine(str.Palindrome());

        #region regex
        string input = "Error: TIMEOUT while calling API";
        string pattern = @"timeout";

        var rx = new Regex(
            pattern,
            RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(150) // match timeout
        );

        Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
        #endregion

        var list = new List<string[]>();
        for(int i=0 ; i<20000 ; i++)
        {
            list.Add(new string[1024]);
        }
        Console.WriteLine("Allocated");
        Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
   }
}
