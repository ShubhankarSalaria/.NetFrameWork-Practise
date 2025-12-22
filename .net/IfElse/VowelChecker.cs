// VowelChecker.cs
// Uses switch to determine vowel or consonant.
using System;

public class VowelChecker
{
    public string CheckChar(char ch)
    {
        char c = char.ToLower(ch);
        switch (c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return ch + " is a vowel.";
            default:
                return ch + " is a consonant.";
        }
    }
}
