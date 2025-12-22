// GradeDescription.cs
// Maps grade letters to descriptions using switch.
using System;

public class GradeDescription
{
    public string Describe(char grade)
    {
        switch (char.ToUpper(grade))
        {
            case 'E': return "Excellent";
            case 'V': return "Very Good";
            case 'G': return "Good";
            case 'A': return "Average";
            case 'F': return "Fail";
            default: return "Unknown grade.";
        }
    }
}
