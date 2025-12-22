// PrimeChecker.cs
// Checks primality using a for loop and break.
using System;

public class PrimeChecker
{
    public string IsPrime(int n)
    {
        if (n <= 1) return n + " is not prime.";
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return n + " is not prime.";
        }
        return n + " is prime.";
    }
}
