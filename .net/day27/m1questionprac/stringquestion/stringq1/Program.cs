
class Program
{

    public static bool EvenOrOdd(string str)
    {
        // StringSplitOptions.RemoveEmptyEntries for removing not required spaces 
        string []arstr = str.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        return arstr.Length % 2 ==0;
    }
    
    public static string  OddStringOps(string str)
    {
        string [] words = str.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        for(int i =0 ; i<words.Length ; i++)
        {
            char[]chars = words[i].ToCharArray();
            Array.Reverse(chars);
            words[i]=new string(chars);
        }
        string result= string.Join(" ",words);
        return result;
    }
    public static string EvenStringOps(string str)
    {
        string [] words = str.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        string result="";
        int n = words.Length;
        for(int i =0 ; i<words.Length ; i++)
        {
            result+=words[n-i-1]+" ";
        }
        return result;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the string value :");
        string input = Console.ReadLine();
        foreach(char c in input)
        {
            if (char.IsDigit(c))
            {
                Console.WriteLine("string contain a number");
                return;
            }
        }
        // for spliting the string use the .split(' ') 
        string result="";
        bool isEven=EvenOrOdd(input);
        if (isEven)
        {
            Console.WriteLine("as the count is even hence");
            result=EvenStringOps(input);
        }
        else
        {
            Console.WriteLine("as the COUNT IS odd here");
            result =OddStringOps(input);
        }
        Console.WriteLine(result);
    }
}