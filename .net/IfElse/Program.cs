// See https://aka.ms/new-console-template for more information


// this the class containing the main method 
public class Program{

    // here main method is define
    public static void Main(string []args){

        // Question 1 
        Console.WriteLine(" Question 1) Height Category :");
        #region Height Category 
        HeightCat obj = new HeightCat();
        Console.WriteLine("Enter the height :");
        string? input = Console.ReadLine();
        if(double.TryParse(input ,out double num )){
            Console.WriteLine(obj.CatHt(num));
        }
        else{
            Console.WriteLine("input is wrong");
        }
        
        #endregion
        // Question 2 
        Console.WriteLine(" Question 2) largest of three :");
        #region Largest of three
        LargestOfThree obj1 = new LargestOfThree();
        int a , b , c; 
        Console.WriteLine("Enter the three number :");
        
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        // printing end result 
        Console.WriteLine("largest of three is : " + obj1.MaxThree(a,b,c));
        #endregion

        // Question 3 
        Console.WriteLine(" Question 3) Leap Year Checker :");
        LeapYearChecker ly = new LeapYearChecker();
        Console.WriteLine("Enter the year :");
        string? yInput = Console.ReadLine();
        if (int.TryParse(yInput, out int year))
        {
            Console.WriteLine(ly.GetLeapYearMessage(year));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 4
        Console.WriteLine(" Question 4) Quadratic Equation Solver :");
        QuadraticEquation qe = new QuadraticEquation();
        Console.WriteLine("Enter coefficients a, b and c (one per line):");
        string? sa = Console.ReadLine();
        string? sb = Console.ReadLine();
        string? sc = Console.ReadLine();
        if (double.TryParse(sa, out double da) && double.TryParse(sb, out double db) && double.TryParse(sc, out double dc))
        {
            Console.WriteLine(qe.GetRootsMessage(da, db, dc));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 5
        Console.WriteLine(" Question 5) Admission Eligibility :");
        AdmissionEligibility adm = new AdmissionEligibility();
        Console.WriteLine("Enter Math, Physics, Chemistry marks (one per line):");
        string? sm1 = Console.ReadLine();
        string? sm2 = Console.ReadLine();
        string? sm3 = Console.ReadLine();
        if (int.TryParse(sm1, out a) && int.TryParse(sm2, out b) && int.TryParse(sm3, out c))
        {
            Console.WriteLine(adm.IsEligible(a, b, c));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 6
        Console.WriteLine(" Question 6) Electricity Bill :");
        ElectricityBill eb = new ElectricityBill();
        Console.WriteLine("Enter units:");
        string? su = Console.ReadLine();
        if (int.TryParse(su, out int units))
        {
            Console.WriteLine(eb.CalculateBill(units));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 7
        Console.WriteLine(" Question 7) Vowel or Consonant :");
        VowelChecker vc = new VowelChecker();
        Console.WriteLine("Enter a character:");
        string? sc1 = Console.ReadLine();
        if (!string.IsNullOrEmpty(sc1))
        {
            Console.WriteLine(vc.CheckChar(sc1[0]));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 8
        Console.WriteLine(" Question 8) Triangle Type :");
        TriangleType tt = new TriangleType();
        Console.WriteLine("Enter three sides (one per line):");
        string? sxa = Console.ReadLine();
        string? sxb = Console.ReadLine();
        string? sxc = Console.ReadLine();
        if (double.TryParse(sxa, out double sa1) && double.TryParse(sxb, out double sb1) && double.TryParse(sxc, out double sca1))
        {
            Console.WriteLine(tt.GetType(sa1, sb1, sca1));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 9
        Console.WriteLine(" Question 9) Quadrant Finder :");
        QuadrantFinder qf = new QuadrantFinder();
        Console.WriteLine("Enter x and y (one per line):");
        string? sx = Console.ReadLine();
        string? sy = Console.ReadLine();
        if (double.TryParse(sx, out double xq) && double.TryParse(sy, out double yq))
        {
            Console.WriteLine(qf.GetQuadrant(xq, yq));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 10
        Console.WriteLine(" Question 10) Grade Description :");
        GradeDescription gd = new GradeDescription();
        Console.WriteLine("Enter grade (E, V, G, A, F):");
        string? sg = Console.ReadLine();
        if (!string.IsNullOrEmpty(sg))
        {
            Console.WriteLine(gd.Describe(sg[0]));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 11
        Console.WriteLine(" Question 11) Valid Date Check :");
        DateValidator dv = new DateValidator();
        Console.WriteLine("Enter day, month, year (one per line):");
        string? sd = Console.ReadLine();
        string? sm = Console.ReadLine();
        string? syy = Console.ReadLine();
        if (int.TryParse(sd, out int day) && int.TryParse(sm, out int month) && int.TryParse(syy, out int yearv))
        {
            Console.WriteLine(dv.IsValidDate(day, month, yearv));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 12
        Console.WriteLine(" Question 12) ATM Withdrawal :");
        ATM atm = new ATM();
        Console.WriteLine("Is card inserted? (y/n):");
        string? scard = Console.ReadLine();
        Console.WriteLine("Is PIN valid? (y/n):");
        string? spin = Console.ReadLine();
        Console.WriteLine("Enter balance:");
        string? sbal = Console.ReadLine();
        Console.WriteLine("Enter withdrawal amount:");
        string? sw = Console.ReadLine();
        bool cardInserted = !string.IsNullOrEmpty(scard) && scard.Trim().ToLower() == "y";
        bool pinValid = !string.IsNullOrEmpty(spin) && spin.Trim().ToLower() == "y";
        if (double.TryParse(sbal, out double balance) && double.TryParse(sw, out double wamt))
        {
            Console.WriteLine(atm.AttemptWithdrawal(cardInserted, pinValid, balance, wamt));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 13
        Console.WriteLine(" Question 13) Profit/Loss :");
        ProfitLoss pl = new ProfitLoss();
        Console.WriteLine("Enter Cost Price and Selling Price (one per line):");
        string? scp = Console.ReadLine();
        string? ssp = Console.ReadLine();
        if (double.TryParse(scp, out double cp) && double.TryParse(ssp, out double sp))
        {
            Console.WriteLine(pl.GetMessage(cp, sp));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 14
        Console.WriteLine(" Question 14) Rock Paper Scissors :");
        RockPaperScissors rps = new RockPaperScissors();
        Console.WriteLine("Player 1 choice (rock/paper/scissors):");
        string? p1 = Console.ReadLine();
        Console.WriteLine("Player 2 choice (rock/paper/scissors):");
        string? p2 = Console.ReadLine();
        if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2))
        {
            Console.WriteLine(rps.Decide(p1, p2));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }

        // Question 15
        Console.WriteLine(" Question 15) Simple Calculator :");
        SimpleCalculator calc = new SimpleCalculator();
        Console.WriteLine("Enter first number:");
        string? sfn = Console.ReadLine();
        Console.WriteLine("Enter second number:");
        string? ssn = Console.ReadLine();
        Console.WriteLine("Enter operator (+ - * /):");
        string? sop = Console.ReadLine();
        if (double.TryParse(sfn, out double fn) && double.TryParse(ssn, out double sn) && !string.IsNullOrEmpty(sop))
        {
            Console.WriteLine(calc.Calculate(fn, sn, sop[0]));
        }
        else
        {
            Console.WriteLine("input is wrong");
        }
    }
}
