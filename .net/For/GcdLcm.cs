// GcdLcm.cs
// Finds GCD and LCM using for-loops.
using System;

public class GcdLcm
{
    public string Get(int x, int y)
    {
        if (x == 0 || y == 0) return "GCD/LCM invalid for zero.";
        int a = Math.Abs(x), b = Math.Abs(y);
        int gcd = 1;
        int min = Math.Min(a, b);
        for (int i = 1; i <= min; i++)
        {
            if (a % i == 0 && b % i == 0) gcd = i;
        }
        long lcm = (long)a / gcd * b;
        return "GCD: " + gcd + ", LCM: " + lcm;
    }
}
