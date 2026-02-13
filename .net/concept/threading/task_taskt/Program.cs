using System;
using System.Threading.Tasks;

public class GreetingService
{
    public async Task<string> GetGreetingAsync(string name)
    {
        await Task.Delay(200); // pretend network delay
        return $"Hello, {name}!";
    }
}
class Program
{
    static async Task Main()
    {
        await SaveAsync();                // Task (no return)
        int total = await GetTotalAsync(); // Task<int> (returns value)
        Console.WriteLine(total);
        
    }

    static async Task SaveAsync()
    {
        await Task.Delay(3000); // pretend we saved to DB
        Console.WriteLine("Saved!");
    }

    static async Task<int> GetTotalAsync()
    {
        await Task.Delay(3000); // pretend we calculated
        return 42;
    }


}