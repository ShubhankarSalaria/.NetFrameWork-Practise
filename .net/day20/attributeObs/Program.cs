public class Program
{
    [Obsolete("use Add(int a , int b) method instead")]
    public int oldadd(int a , int b)
    {
        return a+b;
    }
    public int add(int a , int b)
    {
        return a+b;
    }
}
public class result
{
    static void Main(string[] args)
    {
        Program pr = new Program();
       int result1 =  pr.oldadd(2,3);
       int result2 = pr.add(5,4);
       Console.WriteLine("Result from sum:"+result1);
       Console.WriteLine("resutl form add :"+result2);
    }
}