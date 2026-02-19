using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Sum(new List<int> { 1, 2, 3 }));      // 6
        Console.WriteLine(Sum(new List<double> { 1.5, 2.5 }));  // 4
    }

    public static T Sum<T>(IEnumerable<T> items) where T : struct
    {
        dynamic total = default(T);

        foreach (var item in items)
        {
            total += (dynamic)item;
        }

        return (T)total;
    }
}
