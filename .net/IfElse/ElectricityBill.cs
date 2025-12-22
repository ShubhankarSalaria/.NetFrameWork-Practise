// ElectricityBill.cs
// Calculates electricity bill with slabs and surcharge.
using System;

public class ElectricityBill
{
    // Returns bill amount string including surcharge if applicable.
    public string CalculateBill(int units)
    {
        double bill = 0.0;
        if (units <= 199)
        {
            bill = units * 1.20;
        }
        else if (units <= 400)
        {
            bill = 199 * 1.20 + (units - 199) * 1.50;
        }
        else if (units <= 600)
        {
            bill = 199 * 1.20 + (400 - 199) * 1.50 + (units - 400) * 1.80;
        }
        else
        {
            bill = 199 * 1.20 + (400 - 199) * 1.50 + (600 - 400) * 1.80 + (units - 600) * 2.00;
        }

        double surcharge = 0.0;
        if (bill > 400)
        {
            surcharge = bill * 0.15;
            bill += surcharge;
        }

        return "Bill for " + units + " units: " + bill + (surcharge > 0 ? " (including surcharge " + surcharge + ")" : "");
    }
}
