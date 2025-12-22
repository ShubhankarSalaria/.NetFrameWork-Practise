// FactorialLarge.cs
// Calculates factorial using BigInteger to handle large N.
using System;
using System.Numerics;

public class FactorialLarge
{
    public string Compute(int n)
    {
        if (n < 0) return "Invalid input.";
        BigInteger fact = BigInteger.One;
        for (int i = 2; i <= n; i++) fact *= i;
        return fact.ToString();
    }
}
