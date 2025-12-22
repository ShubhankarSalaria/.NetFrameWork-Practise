// DateValidator.cs
// Validates calendar dates including February 29 on leap years.
using System;

public class DateValidator
{
    public string IsValidDate(int day, int month, int year)
    {
        if (year < 1 || month < 1 || month > 12 || day < 1) return "Invalid date.";

        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        bool isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        if (isLeap) daysInMonth[2] = 29;

        if (day > daysInMonth[month]) return "Invalid date.";
        return "Valid date.";
    }
}
