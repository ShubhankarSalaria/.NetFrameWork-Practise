// See https://aka.ms/new-console-template for more information
public class AbstractEx{
    public static void Main(string[]args){
        Employee emp ; 
        emp = new UsEmp(340);
        emp.CalTax();
        
        emp = new IndiaEmp(340);
        emp.CalTax();
    }
}
