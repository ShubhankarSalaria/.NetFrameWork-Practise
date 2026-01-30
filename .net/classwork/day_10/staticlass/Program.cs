// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(GenPur.GetRno());
        GenPur.Rno=200;
        Console.WriteLine(GenPur.GetRno());
    }
}
