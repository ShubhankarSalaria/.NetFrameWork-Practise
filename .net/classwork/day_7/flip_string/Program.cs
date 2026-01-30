// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Security.Principal;

public class Program
{

    public string CleanAndInvert(string input)
    {
        if(input.Length<6 || !input.All(char.IsLetter))
        {
            return "invalid input";
        }
        string newstr="";
        for (int i=0 ; i < input.Length; i++)
        {
            if (!((int)input[i]%2==0))
            {
                newstr+=input[i];
            }
        }
        string result="";
        for(int j = newstr.Length-1; j>=0 ; j--)
        {
           
            if (j % 2 == 0)
            {
                result+=char.ToUpper(newstr[j]);
            }
            else
            {
                 result+=char.ToLower(newstr[j]);
            }
        }
        return result;
    }
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the string : ");
        string input =Console.ReadLine();
        Program pr = new Program();
        Console.WriteLine(pr.CleanAndInvert(input));
    }
}
