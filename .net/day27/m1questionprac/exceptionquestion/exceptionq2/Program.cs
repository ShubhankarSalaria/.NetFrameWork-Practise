public  class InvalidGadgetException : Exception
{
    public InvalidCastException(string message) : base(message)
    {
        
    }
}
public class GadgetValidatorUtil
{
    
    public bool ValidateGadgetID(string gadgetID)
    {
        
        if (!Regex.IsMatch(gadgetID, @"^[A-Z]\d{3}$"))
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
        return true;
    }

    // Validate Warranty Period
    public bool ValidateWarrantyPeriod(int period)
    {
        if (period < 6 || period > 36)
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
        return true;
    }
}
public class UserInterface
{
    
}