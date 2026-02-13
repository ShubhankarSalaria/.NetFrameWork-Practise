public class CreatorStats
{
    public string CreatorName {get; set;} =string.Empty;
    public double[] WeeklyLikes {get; set;}=Array.Empty<double>();


}

public class Program
{
    public static List<CreatorStats>EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string , int>GetTopPostCounts(List<CreatorStats> records , double likeThreshold)
    {
        Dictionary<string , int>result = new Dictionary<string, int>();
        foreach(var record in records)
        {
            int count=0;
            foreach(double weeklike in record.WeeklyLikes)
            {

                if (weeklike >= likeThreshold)
                {
                    count++;
                }
            }
            result.Add(record.CreatorName,count);
        }
        return result;
    }
    public double CalculateAverageLikes()
    {
        double sum=0;
        int count=0;
        foreach(var val in EngagementBoard)
        {
            foreach(double weeklike in val.WeeklyLikes)
            {
                sum+=weeklike;
                count++;
            }
        }
        return count>0?sum/count:0;
    }
    public static void Main()
    {
        int choice =0;
        while (true)
        {

            Console.WriteLine("Choose from the following : ");
            Console.WriteLine("1. add the  creation: \n");
            Console.WriteLine("2. get the top post counts: \n");
            Console.WriteLine("3. get the overall average weekly likes:\n");
            Console.WriteLine("4.terminate the Program : \n");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice < 1 || choice > 4)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter number only.");
                continue;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            Program pr = new Program();
            if (choice == 1)
            {
                Console.WriteLine("Enter Creator Name :");
                string name = Console.ReadLine();
                double []wk = new double[4];
                for(int i =0 ;i< wk.Length ; i++)
                {
                    try
                    {
                        wk[i]=Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter number only.");
                        i--;
                    }
                }
                CreatorStats record = new CreatorStats()
                {
                    CreatorName=name,
                    WeeklyLikes=wk
                };
                pr.RegisterCreator(record);
                Console.WriteLine("reator registered successfully");
            }
            else if (choice == 2){
                Console.WriteLine("Enter like threshold:");
                   try
                    {
                        int lth=Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter number only.");
                        continue;
                    }
                    var result = pr.GetTopPostCounts(EngagementBoard,lth);
                    foreach(var top in result){
                        Console.WriteLine($"{top.Key}-{top.Value}");
                    }
            }
            else if (choice == 3)
            {
                double average = obj.CalculateAverageLikes();
                Console.WriteLine("Overall average weekly likes: " + average);
            }
            else if (choice == 4)
            {
                Console.WriteLine("Application is terminated");
                break;
            }
        }
    }
}