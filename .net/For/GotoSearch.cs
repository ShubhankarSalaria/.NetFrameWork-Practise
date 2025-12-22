// GotoSearch.cs
// Demonstrates exiting nested loops early using goto when a value is found.
using System;

public class GotoSearch
{
    public string Find(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int fi = -1, fj = -1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == target)
                {
                    fi = i; fj = j;
                    goto FOUND;
                }
            }
        }
    FOUND:
        if (fi == -1) return "Not found.";
        return "Found at (" + fi + "," + fj + ")";
    }
}
