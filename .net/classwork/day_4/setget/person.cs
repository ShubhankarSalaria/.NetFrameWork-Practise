using System.Security.Cryptography.X509Certificates;

/// <summary>
/// this is a simple getter setter property  (full property)
/// </summary>
partial class Person
{
    private string? name; 

    public string Name
    {
        get
        {
            return name ;
        }
        set
        {
            name = value;
        }
    }
}