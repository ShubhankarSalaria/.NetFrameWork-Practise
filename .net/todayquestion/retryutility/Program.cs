using System;
using System.Threading;

public class Program
{
    private static int _tries = 0; 

    public static void Main()
    {
        try
        {
            
            int result = ExecuteWithRetry(() =>
            {
                _tries++;

                Console.WriteLine($"Executing attempt {_tries}");

                if (_tries <= 2)
                    throw new InvalidOperationException("Temporary failure");

                return 999;
            }, maxAttempts: 3);

            Console.WriteLine("Final Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Operation failed: " + ex.Message);
        }
    }

    public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
    {
        
        if (work == null)
            throw new ArgumentNullException(nameof(work));

        if (maxAttempts <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxAttempts),
                "maxAttempts must be greater than 0");

        Exception lastException = null!;

       
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return work(); 
            }
            catch (Exception ex)
            {
                lastException = ex;

                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");

                
                if (attempt == maxAttempts)
                    break;

                Thread.Sleep(500); 
            }
        }

        
        throw lastException;
    }
}
