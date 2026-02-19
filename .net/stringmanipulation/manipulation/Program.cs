public class Program
{
    public static void Main()
    {
        //
        string input = "hello";
        char[] chr  = input.ToCharArray();
        Array.Reverse(chr);
        Console.WriteLine(new string(chr));

        string st = "hello";
        char [] ch = st.ToCharArray();
        Array.Reverse(ch);
        Console.WriteLine(new string(ch));

        // palindrome check 
        string s = "madam";
        string rev = new string(s.Reverse().ToArray());

        string text = "hello";
        Console.WriteLine(text.ToUpper());   // HELLO
        Console.WriteLine(text.ToLower());   // hello

        string text = "   hello   ";
        Console.WriteLine(text.Trim());

        string text = "Shubhankar";
        Console.WriteLine(text.Substring(0, 4));  // Shub

        string text = "Data Science";
        Console.WriteLine(text.Contains("Science"));  // True

        string text = "I like Java";
        Console.WriteLine(text.Replace("Java", "C#"));

        string text = "apple,banana,orange";
        string[] fruits = text.Split(',');

        string text = "hello world";
        Console.WriteLine(text.StartsWith("he"));  // True
        Console.WriteLine(text.EndsWith("ld"));    // True

        string text = "programming";
        Console.WriteLine(text.IndexOf('g')); 
    }
}