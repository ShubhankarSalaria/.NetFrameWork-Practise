// See https://aka.ms/new-console-template for more informatio
using databank;
namespace makestudent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var localStudents = DataBank.GetStudents();
            var SessionsGroup = DataBank.GetSessions();

            foreach(var i in localStudents)
            {
                Console.WriteLine(i.Name);
            }
            
            foreach(var i in SessionsGroup)
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}