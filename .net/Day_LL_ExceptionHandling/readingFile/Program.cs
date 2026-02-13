using System;
using System.IO;

public class FileReader
{
    static void Main()
    {
        string filePath="D:\\capgemini\\lpuEx\\.net\\Day_LL_ExceptionHandling\\sample.txt";
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"unexpected error :{ex.Message}");
        }
    }
}