// SimpleCalculator.cs
// Performs basic arithmetic using switch on operator.
using System;

public class SimpleCalculator
{
    public string Calculate(double a, double b, char op)
    {
        switch (op)
        {
            case '+': return "Result: " + (a + b);
            case '-': return "Result: " + (a - b);
            case '*': return "Result: " + (a * b);
            case '/':
                if (b == 0) return "Division by zero.";
                return "Result: " + (a / b);
            default: return "Unknown operator.";
        }
    }
}
