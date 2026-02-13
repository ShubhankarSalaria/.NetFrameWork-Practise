using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter word1: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter word2: ");
        string word2 = Console.ReadLine();

        Dictionary<char, int> freq1 = GetFrequency(word1);
        Dictionary<char, int> freq2 = GetFrequency(word2);

        int deletions = 0;

        foreach (char ch in freq1.Keys)
        {
            int count1 = freq1[ch];
            int count2 = freq2.ContainsKey(ch) ? freq2[ch] : 0;

            if (count1 > count2)
                deletions += count1 - count2;
        }

        Console.WriteLine("Characters to delete from word1: " + deletions);
    }

    static Dictionary<char, int> GetFrequency(string word)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char ch in word)
        {
            if (freq.ContainsKey(ch))
                freq[ch]++;
            else
                freq[ch] = 1;
        }

        return freq;
    }
}