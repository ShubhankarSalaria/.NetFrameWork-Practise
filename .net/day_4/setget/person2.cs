
/// <summary>
/// read only property is implemented here 
/// "only get"
/// </summary>
partial class Person
{
    private int? rollno =10;

    public int? RollNo
    {
        get
        {
            return rollno;
        }
    } 
}