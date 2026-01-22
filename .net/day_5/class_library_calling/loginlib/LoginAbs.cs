namespace loginlib;

public abstract class LoginAbs
{
    public abstract void login(string username , string password);
    public abstract void logout();

    public void loginProcess(){
        Console.WriteLine("this is the login process");
    }
}
