// LeapYearChecker.cs
// Provides a simple if-else based leap year checker.
// Rule: A year is a leap year if it is divisible by 400,
// or it is divisible by 4 but not by 100.

using System;

public class LeapYearChecker
{
    // Returns a human-readable message stating whether 'year' is a leap year.
    // Uses simple if-else branching to implement the leap-year rules.
    public string GetLeapYearMessage(int year)
    {
        if (year % 400 == 0)
        {
            return year + " is a leap year.";
        }
        else if (year % 100 == 0)
        {
            return year + " is not a leap year.";
        }
        else if (year % 4 == 0)
        {
            return year + " is a leap year.";
        }
        else
        {
            return year + " is not a leap year.";
        }
    }
}
