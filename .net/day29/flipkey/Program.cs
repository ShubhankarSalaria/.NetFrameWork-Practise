
public class Program
{
    public string CleanAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("the input you give is invalid");
            return String.Empty;
        }
        foreach(char c in input)
        {
            if (!char.IsAsciiLetter(c))
            {
                Console.WriteLine("this input you give contains number");
                return String.Empty;
            }
        }
        List<char>chrarr=new List<char>();
        foreach(var c in input)
        {
            if (!((int)c % 2 == 0))
            {
                chrarr.Add(c);
            }
        }
        chrarr.Reverse();
        for(int i =0 ; i < chrarr.Count; i++)
        {
            if (i % 2 == 0)
            {
                chrarr[i]=char.ToUpper(chrarr[i]);
            }
        }
        return new string(chrarr.ToArray());
    }
    public static void Main(string []args)
    {
        Program p = new Program();
        Console.WriteLine(p.CleanAndInvert("AbCdEf"));
    }
}