// DigitalRoot.cs
// Repeatedly sums digits until a single-digit result using for-loops.
using System;

public class DigitalRoot
{
    public string Compute(int n)
    {
        n = Math.Abs(n);
        while (n >= 10)
        {
            int sum = 0;
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++) sum += s[i] - '0';
            n = sum;
        }
        return n.ToString();
    }
}
