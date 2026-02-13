

using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
         Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        string maskedPassword = MaskPassword(password);

        Console.WriteLine($"Masked Password: {maskedPassword}");
    }
    public static string MaskPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return "";
        }
        if (password.Length < 3)
        {
            return password;
        }
        StringBuilder sb = new StringBuilder();
        for(int i =0 ; i<password.Length ; i++)
        {
            if(i ==0 || i == password.Length - 1)
            {
                sb.Append(password[i]);
            }
            else
            {
                sb.Append('*');
            }
        }
        return sb.ToString();

        if (false)
        {
            string star = new string('*',sb.Length-2);
            return password[0]+star+password[password.Length-1];
        }
    }
}