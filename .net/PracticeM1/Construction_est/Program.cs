class EstimateDetails
{
    public float ConstructionArea {get; set;}
    public float SiteArea{get; set;}
}
class ConstructionEstimateException : Exception
{
    public ConstructionEstimateException(string message) : base(message)
    {
        
    }
}
class Program
{
    public EstimateDetails ValidateConstructionEstimate(float Construction_Area , float siteArea)
    {
        if(Construction_Area < siteArea)
        {
            throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
        }
        EstimateDetails empDet = new EstimateDetails
        {
          SiteArea=siteArea,
          ConstructionArea=Construction_Area,  
        };
    }

    public static void Main(string[] args)
    {
        Program pr = new Program();
        int Construction_Area=0;
        int siteArea=0;
        
        Console.WriteLine("Enter the Construction_Area : ");
        if (!int.TryParse(Console.ReadLine(),out int CA))
        {
            Construction_Area=CA;
        }
        Console.WriteLine("enter")
        
    }
}