/// <summary>
/// getter setter with the validation
/// </summary>

partial class Person
{
    private int age;
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if(value >= 0)
            {
                age = value ;
            }
            else
            {
                Console.WriteLine("age cant be negative");
            }
        }
    }
}