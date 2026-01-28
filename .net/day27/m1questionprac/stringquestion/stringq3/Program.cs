using System;

class PasswordGenerator
{
    // Method to validate username
    static bool IsValidUsername(string username)
    {
        // Length must be exactly 8
        if (username.Length != 8)
            return false;

        // First 4 characters must be uppercase alphabets
        for (int i = 0; i < 4; i++)
        {
            if (!char.IsUpper(username[i]))
                return false;
        }

        // 5th character must be '@'
        if (username[4] != '@')
            return false;

        // Last 3 characters must be digits
        string courseIdStr = username.Substring(5, 3);
        if (!int.TryParse(courseIdStr, out int courseId))
            return false;

        // Course ID must be between 101 and 115
        if (courseId < 101 || courseId > 115)
            return false;

        return true;
    }

    // Method to generate password
    static string GeneratePassword(string username)
    {
        int sum = 0;

        // Convert first 4 characters to lowercase and sum ASCII values
        for (int i = 0; i < 4; i++)
        {
            char ch = char.ToLower(username[i]);
            sum += (int)ch;
        }

        // Last 2 digits of course ID
        string lastTwoDigits = username.Substring(6, 2);

        return "TECH_" + sum + lastTwoDigits;
    }

    static void Main()
    {
        Console.WriteLine("Enter the username");
        string username = Console.ReadLine();

        if (!IsValidUsername(username))
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        string password = GeneratePassword(username);
        Console.WriteLine("Password: " + password);
    }
}
