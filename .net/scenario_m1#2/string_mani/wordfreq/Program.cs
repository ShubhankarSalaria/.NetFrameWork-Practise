public class Program
{
    public static void Main()
    {
         Console.Write("Enter Sentence: ");
        string sentence = Console.ReadLine();
        WordCountDisplay(sentence);
    }

    public static void WordCountDisplay(string sentence)
    {
        sentence.ToLower();
        string [] strarry =  sentence.Split(new char[]{' ','\t','\n'},StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string,int> freqCount = new Dictionary<string,int>();
        foreach(string str in strarry)
        {
            if (freqCount.ContainsKey(str))
            {
                freqCount[str]++;
            }
            else
            {
                freqCount[str]=1;
            }
        }
        foreach( var item in freqCount)
        {
            Console.WriteLine($"{item.Value}:{item.Key}");
        }
    }
}