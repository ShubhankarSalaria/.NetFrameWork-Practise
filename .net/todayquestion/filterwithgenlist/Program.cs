using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var nums = new List<int> { 2, 5, 8, 11, 14 };

        var evens = Filter(nums, n => n % 2 == 0);
        Console.WriteLine(string.Join(",", evens));   // 2,8,14

        var big = Filter(nums, n => n >= 10);
        Console.WriteLine(string.Join(",", big));     // 11,14
    }

    public static List<T> Filter<T>(List<T> items, Predicate<T> match)
    {
        var result = new List<T>();

        foreach (var item in items)
        {
            if (match(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}
