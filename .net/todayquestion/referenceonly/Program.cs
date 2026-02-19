using System;

public class Program
{
    public static void Main()
    {
        var cache = new RefCache<string>();         // ✅ Allowed (string is class)
        cache.Set(null);                            
        Console.WriteLine(cache.GetOrDefault("NA")); // NA

        cache.Set("Hello");
        Console.WriteLine(cache.GetOrDefault("NA")); // Hello

        // var wrong = new RefCache<int>();          // ❌ Won’t compile (int is struct)
    }
}

public class RefCache<T> where T : class            // Constraint: reference types only
{
    private T? _value;                              

    public void Set(T? value)
    {
        _value = value;
    }

    public T GetOrDefault(T defaultValue)
    {
        return _value ?? defaultValue;
    }
}
