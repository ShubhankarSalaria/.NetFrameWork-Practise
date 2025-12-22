// ReversePalindrome.cs
// Reverses an integer and checks palindrome using for/while where appropriate.
using System;

public class ReversePalindrome
{
    public string Check(int num)
    {
        int original = Math.Abs(num);
        string s = original.ToString();
        string rev = "";
        for (int i = s.Length - 1; i >= 0; i--) rev += s[i];
        int r = int.Parse(rev);
        bool pal = r == original;
        return "Reversed: " + r + ", Palindrome: " + (pal ? "Yes" : "No");
    }
}
