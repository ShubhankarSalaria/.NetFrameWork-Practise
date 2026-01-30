public static class GenPur
{
    public static int Rno {get; set;}
    static GenPur(){
        Rno=100;
    }
    public static int GetRno()
    {
        return Rno;
    }
}