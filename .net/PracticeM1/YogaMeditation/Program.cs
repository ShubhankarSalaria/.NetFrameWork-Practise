
using System.Collections;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;

class MeditationCenter
{
    public int MemberId{get; set;}
    public int Age{get; set;}
    public double Weight {get; set;}
    public double Height{get; set;}
    public string Goal {get; set;}
    public double BMI{get; set;} 
}
public class Program
{
    public static ArrayList memberList = new ArrayList();
    public void AddYogaMember(int memberId, int age , double weighht , double height , string goal)
    {
        MeditationCenter m1 = new MeditationCenter
        {
          MemberId = memberId,
          Age=age,
          Weight=weighht,
          Height = height,
          Goal=goal
        };
        memberList.Add(m1);
    }

    public double CalculateBMI(int memberid)
    {
        
        double BMI = 0;
        foreach(MeditationCenter member in memberList)
        {
            if (memberid == member.MemberId)
            {
                BMI = member.Weight/(member.Height*member.Height);
                member.BMI=BMI;
                break;
            }
        }

        return Math.Floor(BMI);
    }

    public int CalculateYogaFee(int memberId)
    {
        int result=0;
        foreach (MeditationCenter member in memberList)
        {
            
            if (member.MemberId == memberId)
            {
                if(member.BMI>=25&&  member.BMI< 30)
                {
                    result=2000;
                }
                else if(member.BMI>=30 && member.BMI < 35)
                {
                    result=2500;
                }
                else if (member.BMI >= 35)
                {
                    result=3000;
                }
                else
                {
                    result=2500;
                }
            }
        }
        return result;
    }
    public static void Main(string[] args)
    {
        Program pr = new Program();
        pr.AddYogaMember(1, 25, 70, 1.70, "Weight Loss");
        pr.AddYogaMember(2, 30, 85, 1.65, "Fitness");
        pr.AddYogaMember(3, 40, 95, 1.72, "Stress Relief");
        pr.AddYogaMember(4, 28, 60, 1.68, "Flexibility");
        foreach (MeditationCenter member in memberList)
        {
            double bmi = pr.CalculateBMI(member.MemberId);
            int fee = pr.CalculateYogaFee(member.MemberId);
            Console.WriteLine($"Member ID: {member.MemberId}");
            Console.WriteLine($"BMI: {bmi}");
            Console.WriteLine($"Yoga Fee: {fee}");
            Console.WriteLine("-----------------------");
        }
    }

}