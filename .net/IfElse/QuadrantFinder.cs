// QuadrantFinder.cs
// Determines which quadrant or axis a point (x,y) lies in.
using System;

public class QuadrantFinder
{
    public string GetQuadrant(double x, double y)
    {
        if (x == 0 && y == 0) return "Origin.";
        if (x == 0) return "On Y axis.";
        if (y == 0) return "On X axis.";
        if (x > 0 && y > 0) return "Quadrant I.";
        if (x < 0 && y > 0) return "Quadrant II.";
        if (x < 0 && y < 0) return "Quadrant III.";
        return "Quadrant IV.";
    }
}
