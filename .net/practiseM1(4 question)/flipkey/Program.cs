﻿using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
public class FlipKey
{
    public string CleanseAndInvert(string input)
    {
        if (input == null || input.Length < 6)
        {
            return "";
        }
        input = input.ToLower();
        string sb = "";
        foreach (char ch in input)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                if ((int)ch % 2 != 0)
                {
                    sb += ch;
                }
            }
        }
        sb = new string(sb.Reverse().ToArray());
        char[] ca = sb.ToCharArray();
        int n = ca.Length;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                ca[i] = char.ToUpper(ca[i]);
            }
        }


        return new string(ca);
    }


    // again 
    public string CleanseAndInvert2(string input)
    {
        if (string.IsNullOrEmpty(input)&&input.Length>6)
        {
            return string.Empty;   
        }
        input=input.ToLower();
        StringBuilder filtered = new StringBuilder();
        foreach(char c in input)
        {
            if (!((int)c % 2 == 0))
            {
                filtered.Append(c);
            }
        }
        
        char []arr=filtered.ToString().ToCharArray();
        Array.Reverse(arr);
        for(int i =0 ; i<arr.Length; i++)
        {
            if(i%2==0)
            {
                arr[i]=char.ToUpper(arr[i]);
            }
        }
        return new string(arr);
    }
}
public class Program
{
    public static void Main()
    {
        FlipKey c = new FlipKey();
        Console.WriteLine(c.CleanseAndInvert2("abcdef"));
    }
}


