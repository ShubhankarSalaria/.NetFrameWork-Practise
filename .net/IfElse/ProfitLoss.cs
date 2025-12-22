// ProfitLoss.cs
// Calculates profit or loss percentage.
using System;

public class ProfitLoss
{
    public string GetMessage(double costPrice, double sellingPrice)
    {
        if (costPrice <= 0) return "Invalid cost price.";
        double diff = sellingPrice - costPrice;
        double percent = Math.Abs(diff) / costPrice * 100.0;
        if (diff > 0) return "Profit of " + percent + "%";
        if (diff < 0) return "Loss of " + percent + "%";
        return "No profit no loss.";
    }
}
