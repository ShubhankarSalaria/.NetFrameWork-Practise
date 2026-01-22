using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

class Program
{
    public static SortedDictionary<string , long> itemDetails= new SortedDictionary<string, long>();

    
    public SortedDictionary<string , long> FinditemDetails(long SoldCount)
    {
        SortedDictionary<string , long>answer=new SortedDictionary<string, long>();
        foreach(var item in itemDetails)
        {
            if (item.Value == SoldCount)
            {
                answer.Add(item.Key,item.Value);
            }
        }
        return answer;
    }

    public List<string> FindMinandMaxSoldItems()
    {
        var SortItemDetails = itemDetails.OrderBy(x=>x.Value);
        List<string>ans=new List<string>();
        var list = SortItemDetails.ToList();
        ans.Add(list[0].Key);
        ans.Add(list[list.Count-1].Key);
        return ans;
    }
    public Dictionary<string,long> SortByCount()
    {
        var SortItemDetails = itemDetails.OrderBy(x=>x.Value);
        return SortItemDetails.ToDictionary();
    }
    public static void Main(string[] args)
    {
        itemDetails.Add("hello",234);
        itemDetails.Add("bye",2351);
        itemDetails.Add("world",236);
        Program pr  = new Program();
        var dic = pr.SortByCount();
        var list=pr.FindMinandMaxSoldItems();
        var sortDic = pr.FinditemDetails(234);

        Console.WriteLine(" This is the dictornary : ");
        foreach ( var item in dic)
        {
            Console.WriteLine($"{item.Key}  {item.Value}");
        }
        Console.WriteLine(" This is list : ");
        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }
        foreach (var item in sortDic)
        {
            Console.WriteLine($"{item.Key}  {item.Value}");
        }
        
    }
}