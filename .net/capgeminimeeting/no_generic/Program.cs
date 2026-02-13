using System;

class NonGen
{
    private object value;

    public void SetValue(object val)
    {
        value = val;
    }

    public object GetValue()
    {
        return value;
    }
}


class Gen<T>
{
    private T value;

    public void SetValue(T val)
    {
        value = val;
    }

    public T GetValue()
    {
        return value;
    }
}



class Program
{
    static void Main()
    {
        // non generic version
        NonGen b = new NonGen();

        b.SetValue(10);  

        int num = (int)b.GetValue(); 

        Console.WriteLine(num);

        // generic one 
        Gen<int> b2 = new Gen<int>();

        b2.SetValue(10);

        int num2 = b.GetValue(); 

        Console.WriteLine(num2);
    }
}