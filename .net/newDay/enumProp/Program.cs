// See https://aka.ms/new-console-template for more information
public enum WeekDays
{
    Sunday,
    Monday,
    tuesday,
    wednesday,
    thursday,
    Friday,
    Saturday
}

public enum Product
{
    Electronics=1,
    Clothing = 2, 
    Groceries = 3,
    Furniture = 4
}

public class Program
{
    public static void Main(string []args)
    {
        WeekDays today = WeekDays.wednesday;
        Console.WriteLine("Today is "+today);
        int enumValue = (int)WeekDays.Friday;
        Product category =Product.Electronics;
        Console.WriteLine("Selected category "+category + "With Value "+(int)category);

        int numValuePara = 0 ; 
        string variableForDay = GetWeekDay(WeekDays.thursday,ref numValuePara);
        Console.WriteLine(variableForDay);
        Console.WriteLine(numValuePara);
        Console.WriteLine(MenuByDay(WeekDays.thursday));
    }
    public static string GetWeekDay(WeekDays weekDays, ref int  numValue)
    {
             numValue = (int)weekDays;
            return weekDays.ToString();
    }
    public static string MenuByDay(WeekDays day)
        {
            switch(day)
            {
                case WeekDays.Monday:
                    return "Pasta";
                case WeekDays.tuesday:
                    return "Tacos";
                case WeekDays.wednesday:
                    return "Chicken Curry";
                case WeekDays.thursday:
                    return "Pizza";
                case WeekDays.Friday:
                    return "Fish and Chips";
                case WeekDays.Saturday:
                    return "Burgers";
                case WeekDays.Sunday:
                    return "Roast Dinner";
                default:
                    return "Unknown Day";
            }
        }
}