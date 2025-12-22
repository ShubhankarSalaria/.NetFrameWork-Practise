// Fibonacci.cs
// Displays first N terms of the Fibonacci sequence using for-loops.
using System;

public class Fibonacci
{
    public string GetSeries(int n)
    {
        if (n <= 0) return "No terms.";
        if (n == 1) return "0";

        long a = 0, b = 1;
        string res = "0";
        for (int i = 2; i <= n; i++)
        {
            res += ", " + b;
            long next = a + b;
            a = b;
            b = next;
        }
        return res;
    }
}
