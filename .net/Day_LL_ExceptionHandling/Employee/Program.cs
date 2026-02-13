public class BonusCalculator
{
    static void Main()
    {
        int [] salaries = {5000 , 0 , 7000};
        foreach(var sal in salaries)
        {
            Console.WriteLine(sal);
        }
        int bonus = 10000;
        double result = 0;
        for(int i = 0 ; i< salaries.Length ; i++)
        {
            try
            {
                result = bonus/salaries[i];
                Console.WriteLine($"Salary to the bonus ratio of emp{i+1}: {result:F2}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"salary of the {i+1} employee is comming out be zero");
            }
        }
    }
}