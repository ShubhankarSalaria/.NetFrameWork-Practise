// See https://aka.ms/new-console-template for more information
using MyLibrary;
using Mylibrary2;
public class Program{
    public static void Main(string []args){
        Calcadd cal = new Calcadd();
        CalcSub cal1 = new CalcSub();
        Console.WriteLine(cal.add(1,2));
        Console.WriteLine(cal1.sub(3,4));

        LibLogin ll = new LibLogin();
        ll.login("hello","bro");
    }
}