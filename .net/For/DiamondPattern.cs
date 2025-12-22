// DiamondPattern.cs
// Prints a diamond of '*' characters using nested for-loops.
using System;

public class DiamondPattern
{
    public string Get(int n)
    {
        if (n <= 0) return "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int mid = n;
        // upper
        for (int i = 0; i <= mid; i++)
        {
            for (int j = 0; j < mid - i; j++) sb.Append(' ');
            for (int j = 0; j < 2 * i + 1; j++) sb.Append('*');
            sb.AppendLine();
        }
        // lower
        for (int i = mid - 1; i >= 0; i--)
        {
            for (int j = 0; j < mid - i; j++) sb.Append(' ');
            for (int j = 0; j < 2 * i + 1; j++) sb.Append('*');
            if (i > 0) sb.AppendLine();
        }
        return sb.ToString();
    }
}
