// PascalsTriangle.cs
// Prints Pascal's triangle up to N rows using nested for-loops.
using System;

public class PascalsTriangle
{
    public string GetRows(int n)
    {
        if (n <= 0) return "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < n; i++)
        {
            int val = 1;
            for (int j = 0; j <= i; j++)
            {
                sb.Append(val);
                if (j < i) sb.Append(" ");
                val = val * (i - j) / (j + 1);
            }
            if (i < n - 1) sb.AppendLine();
        }
        return sb.ToString();
    }
}
