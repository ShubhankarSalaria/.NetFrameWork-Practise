
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("ENTER THE EMAIL VALID (ALPHANUMERICONLY@GMAIL.COM)");
        string domain = Console.ReadLine();
        Console.WriteLine((EmailChecker(domain))?"valid":"Invalid");
    }
    public static bool EmailChecker(string domain)
    {
        domain=domain.Trim();
        if (string.IsNullOrWhiteSpace(domain))
        {
            return false;
        }
        string []strarr = domain.Split('@');
        if (!(strarr.Length==2))
        {
            return false ;
        }
        string firstword = strarr[0];

        if(firstword.Length == 0)
        {
            return false;
        }
        foreach( char ch in firstword)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                return false;
            }
        }
        string secondpart =strarr[1];
        if (secondpart != "gmail.com")
        {
            return false;
        }
        
        return true;
    }
}