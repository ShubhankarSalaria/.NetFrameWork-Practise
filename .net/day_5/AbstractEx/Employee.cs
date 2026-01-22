public abstract class Employee{

    public  int Empid{get; set;}
    public string Empname{get; set;}
    public int Sal{get; set;}
    public string taxSlab{get; set;}

    protected Employee(int Sal){
        this.Sal=Sal;
    }
    public abstract void CalTax();   
}

public class IndiaEmp: Employee{

    public IndiaEmp(int Sal):base(Sal){

    }
    public override void CalTax(){
        Console.WriteLine("indian employee sal : "+Sal);
    }
}

public class UsEmp: Employee{

    public UsEmp(int Sal):base(Sal){

    }
    public override void CalTax(){
        Console.WriteLine("usa employee sal : "+Sal);
    }
}