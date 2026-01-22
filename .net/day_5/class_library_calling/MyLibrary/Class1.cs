namespace MyLibrary;
using loginlib;

public class  LibLogin : LoginAbs{
    public override void login(string username , string password){
        Console.WriteLine($"{username} : {password}");
    }
    public override void logout(){
        Console.WriteLine("this is a logout ");
    }
}
public class Calcadd
{
    public int add(int a , int b ){
        return a+b;
    }
}
