// AdmissionEligibility.cs
// Checks admission eligibility using simple if-else logic.
using System;

public class AdmissionEligibility
{
    // Returns eligibility message based on given marks.
    public string IsEligible(int math, int phys, int chem)
    {
        int total = math + phys + chem;
        if (math >= 65 && phys >= 55 && chem >= 50)
        {
            if (total >= 180 || (math + phys) >= 140)
            {
                return "Eligible for admission.";
            }
            else
            {
                return "Not eligible: total or math+phys requirement not met.";
            }
        }
        else
        {
            return "Not eligible: minimum marks in individual subjects not met.";
        }
    }
}
