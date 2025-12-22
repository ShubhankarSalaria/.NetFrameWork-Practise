// BinaryToDecimal.cs
// Converts binary string to decimal without built-ins, using for-loop.
using System;

public class BinaryToDecimal
{
    public string Convert(string bin)
    {
        if (string.IsNullOrEmpty(bin)) return "Invalid input.";
        int result = 0;
        for (int i = 0; i < bin.Length; i++)
        {
            char c = bin[bin.Length - 1 - i];
            if (c != '0' && c != '1') return "Invalid binary.";
            if (c == '1') result += (1 << i);
        }
        return "Decimal: " + result;
    }
}
