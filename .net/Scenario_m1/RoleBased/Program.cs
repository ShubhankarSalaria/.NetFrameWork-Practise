using System;

public enum Role
{
    Admin,
    Manager,
    Agent
}

public enum Permission
{
    CreateLoan,
    ApproveLoan,
    RejectLoan,
    ViewAll,
    ViewSelf
}


public class User
{
    public string UserId { get; set; } = string.Empty;
    public Role Role { get; set; }

    // Manager specific approval limit
    public decimal ApprovalLimit { get; set; }
}


public class LoanResource
{
    public string OwnerUserId { get; set; } = string.Empty;
    public decimal LoanAmount { get; set; }
}


public class AuthorizationEngine
{
    public bool Authorize(User user, Permission permission, LoanResource resource)
    {
        switch (user.Role)
        {
            case Role.Admin:
                // Admin has full access
                return true;

            case Role.Manager:
                return AuthorizeManager(user, permission, resource);

            case Role.Agent:
                return AuthorizeAgent(user, permission, resource);

            default:
                return false;
        }
    }

   
    private bool AuthorizeManager(User user, Permission permission, LoanResource resource)
    {
        switch (permission)
        {
            case Permission.CreateLoan:
            case Permission.ViewAll:
            case Permission.ViewSelf:
            case Permission.RejectLoan:
                return true;

            case Permission.ApproveLoan:
                // Manager approval limited by amount
                return resource.LoanAmount <= user.ApprovalLimit;

            default:
                return false;
        }
    }


    private bool AuthorizeAgent(User user, Permission permission, LoanResource resource)
    {
        switch (permission)
        {
            case Permission.CreateLoan:
                return true;

            case Permission.ViewSelf:
                // Agent can only view own resources
                return resource.OwnerUserId == user.UserId;

            case Permission.ViewAll:
            case Permission.ApproveLoan:
            case Permission.RejectLoan:
                return false;

            default:
                return false;
        }
    }
}


public class Program
{
    public static void Main()
    {
        AuthorizationEngine engine = new AuthorizationEngine();

        User admin = new User { UserId = "A1", Role = Role.Admin };
        User manager = new User { UserId = "M1", Role = Role.Manager, ApprovalLimit = 500000 };
        User agent = new User { UserId = "AG1", Role = Role.Agent };

        LoanResource loan = new LoanResource
        {
            OwnerUserId = "AG1",
            LoanAmount = 300000
        };

        Console.WriteLine("Admin Approve Loan: " +
            engine.Authorize(admin, Permission.ApproveLoan, loan));

        Console.WriteLine("Manager Approve Loan: " +
            engine.Authorize(manager, Permission.ApproveLoan, loan));

        Console.WriteLine("Agent View Own Loan: " +
            engine.Authorize(agent, Permission.ViewSelf, loan));

        Console.WriteLine("Agent Approve Loan: " +
            engine.Authorize(agent, Permission.ApproveLoan, loan));

        // Test Manager limit
        loan.LoanAmount = 700000;

        Console.WriteLine("Manager Approve High Amount Loan: " +
            engine.Authorize(manager, Permission.ApproveLoan, loan));
    }
}
