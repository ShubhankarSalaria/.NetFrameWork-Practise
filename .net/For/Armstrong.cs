// Armstrong.cs
// Checks Armstrong numbers using for-loops.
using System;

public class Armstrong
{
    public string Check(int num)
    {
        if (num < 0) return "Invalid number.";
        string s = num.ToString();
        int pow = s.Length;
        int sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int d = s[i] - '0';
            int p = 1;
            for (int j = 0; j < pow; j++) p *= d;
            sum += p;
        }
        return sum == num ? num + " is an Armstrong number." : num + " is not an Armstrong number.";
    }
}
