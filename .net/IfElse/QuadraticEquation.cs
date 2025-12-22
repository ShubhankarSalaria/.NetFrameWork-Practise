// QuadraticEquation.cs
// Computes roots of ax^2 + bx + c = 0 using simple if-else checks
// on the discriminant to determine the nature of the roots.

using System;

public class QuadraticEquation
{
    // Returns a human-readable message describing the roots.
    // Handles: a == 0 (linear or invalid), discriminant >0 (two real roots),
    // =0 (one real root), <0 (two complex roots).
    public string GetRootsMessage(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                return "Not an equation (a and b are both zero).";
            }
            double root = -c / b;
            return "Linear equation. Single root: " + root;
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double sqrtD = Math.Sqrt(discriminant);
            double r1 = (-b + sqrtD) / (2 * a);
            double r2 = (-b - sqrtD) / (2 * a);
            return "Two distinct real roots: " + r1 + " and " + r2;
        }
        else if (discriminant == 0)
        {
            double r = -b / (2 * a);
            return "One real root (double): " + r;
        }
        else
        {
            double realPart = -b / (2 * a);
            double imagPart = Math.Sqrt(-discriminant) / (2 * a);
            return "Two complex roots: " + realPart + " + " + imagPart + "i and " + realPart + " - " + imagPart + "i";
        }
    }
}
