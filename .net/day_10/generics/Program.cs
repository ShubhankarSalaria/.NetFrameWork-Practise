class Repo<T>
{
    private T[] data = new T[10];
    private int index = 0;

    public void Add(T item)
    {
        data[index++]=item;
    }

    public T Get(int i)
    {
        return data[i];
    }
}

class Program 
{
    public static void Main(string[] args)
    {
        Repo<int> intRepo = new Repo<int>();
        intRepo.Add(100);
        intRepo.Add(200);
        
        int a = intRepo.Get(0);
        Console.WriteLine(a);

        Repo<string> strRepo = new Repo<string>();
        strRepo.Add("a");
        strRepo.Add("b");
        strRepo.Add("C");
        Console.WriteLine(strRepo.Get(0));
    }
}