// TriangleType.cs
// Determines triangle type: Equilateral, Isosceles, or Scalene.
using System;

public class TriangleType
{
    public string GetType(double a, double b, double c)
    {
        // Check for validity first (triangle inequality)
        if (a <= 0 || b <= 0 || c <= 0) return "Invalid side lengths.";
        if (a + b <= c || a + c <= b || b + c <= a) return "Not a triangle.";

        if (a == b && b == c) return "Equilateral triangle.";
        if (a == b || b == c || a == c) return "Isosceles triangle.";
        return "Scalene triangle.";
    }
}
