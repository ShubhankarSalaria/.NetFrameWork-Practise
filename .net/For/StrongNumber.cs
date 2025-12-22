// StrongNumber.cs
// Checks if sum of factorial of digits equals the number.
using System;

public class StrongNumber
{
    public string Check(int n)
    {
        if (n < 0) return "Invalid input.";
        int original = n;
        int sum = 0;
        for (int temp = n; temp > 0; temp /= 10)
        {
            int d = temp % 10;
            int fact = 1;
            for (int i = 2; i <= d; i++) fact *= i;
            sum += fact;
        }
        return sum == original ? n + " is a Strong number." : n + " is not a Strong number.";
    }
}
