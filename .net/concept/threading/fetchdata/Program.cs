using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    // Simulating UI controls
    static bool _btn = true;
    static string _status = "Idle";
    static HttpClient _http = new HttpClient();

    static async Task Main()
    {
        await FetchJsonAsync();

        Console.ReadLine();
    }

    private static async Task FetchJsonAsync()
    {
        _btn = false;
        _status = "Status: Fetching...";
        Console.WriteLine(_status);

        Console.WriteLine("\n---- " + DateTime.Now.ToString("HH:mm:ss.fff") + " ----");

        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            string json = await _http.GetStringAsync(url); 

            Console.WriteLine(json);
            _status = "Status: Success";
            Console.WriteLine(_status);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            _status = "Status: Failed";
            Console.WriteLine(_status);
        }
        finally
        {
            _btn = true;
        }
    }
}
