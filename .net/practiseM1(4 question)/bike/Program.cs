using System.Diagnostics.Contracts;

public class Bike
{
    public string Model {get; set;}
    public string Brand {get; set;}
    public double PricePerDay{get; set;}
}

public class BikeUtility
{
    public void AddBikeDetails(string model , string brand , int pricePerDay)
    {
        Program.bikeId++;
        Bike bike = new Bike()
        {
            Model=model,
            Brand=brand,
            PricePerDay=pricePerDay
        };
        Program.bikeDetails.Add(Program.bikeId,bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string,List<Bike>> result = new SortedDictionary<string,List<Bike>>();
        foreach(Bike bike in Program.bikeDetails.Values)
        {
            if (!result.ContainsKey(bike.Brand))
            {
                result[bike.Brand]=new List<Bike>();
            }
            result[bike.Brand].Add(bike);
        }
        return result;
    }
}

public class Program
{
    public static SortedDictionary<int,Bike> bikeDetails=new SortedDictionary<int, Bike>();

    public static int bikeId=0;
    static void Main()
    {
        BikeUtility utitlity = new BikeUtility();
        while (true)
        {
            Console.WriteLine("1.Add bike Details");
            Console.WriteLine("2. Group bikes by Brand");
            Console.WriteLine("3.Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter the brand");
                string brand = Console.ReadLine();
                
                Console.WriteLine(" Enter the model ");
                string model = Console.ReadLine();

                Console.WriteLine("Enter the price per day ");
                int price = int.Parse(Console.ReadLine());

                utitlity.AddBikeDetails(model,brand,price);
                Console.WriteLine("Bike details added successfully");
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                SortedDictionary<string ,List<Bike>> grouped = utitlity.GroupBikesByBrand();
                foreach (var item in grouped)
                {
                    Console.Write(item.Key+" : ");
                    foreach (Bike bike in item.Value)
                    {
                        Console.WriteLine(bike.Model);
                    }
                    Console.WriteLine();
                }
            }
            else if (choice == 3)
            {
                break;
            }
            
        }
    }

    
}
