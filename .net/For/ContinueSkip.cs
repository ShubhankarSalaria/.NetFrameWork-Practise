// ContinueSkip.cs
// Prints numbers 1..50 skipping multiples of 3 using continue inside a for-loop.
using System;

public class ContinueSkip
{
    public string Get()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0) continue;
            if (sb.Length > 0) sb.Append(", ");
            sb.Append(i);
        }
        return sb.ToString();
    }
}
