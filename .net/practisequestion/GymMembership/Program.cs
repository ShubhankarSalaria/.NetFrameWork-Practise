public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MembershipType { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Member(int id, string name, string type, int months)
    {
        MemberId = id;
        Name = name;
        MembershipType = type;
        JoinDate = DateTime.Now;
        ExpiryDate = JoinDate.AddMonths(months);
    }

    // Helper Property
    public bool IsActive => DateTime.Now <= ExpiryDate;
}



public class FitnessClass
{
    public string ClassName { get; set; }
    public string Instructor { get; set; }
    public DateTime Schedule { get; set; }
    public int MaxParticipants { get; set; }
    public List<int> RegisteredMembers { get; set; }

    public FitnessClass(string className, string instructor, DateTime schedule, int maxParticipants)
    {
        ClassName = className;
        Instructor = instructor;
        Schedule = schedule;
        MaxParticipants = maxParticipants;
        RegisteredMembers = new List<int>();
    }

    public int AvailableSeats => MaxParticipants - RegisteredMembers.Count;
}

public class GymManager
{
    private List<Member> members = new List<Member>();
    private List<FitnessClass> classes = new List<FitnessClass>();
    private int memberCounter = 1;

    // Add Member
    public void AddMember(string name, string membershipType, int months)
    {
        if (months <= 0)
        {
            Console.WriteLine("Invalid membership duration.");
            return;
        }

        members.Add(new Member(memberCounter++, name, membershipType, months));
    }

    // Add Fitness Class
    public void AddClass(string className, string instructor,
                         DateTime schedule, int maxParticipants)
    {
        if (maxParticipants <= 0)
        {
            Console.WriteLine("Invalid participant count.");
            return;
        }

        classes.Add(new FitnessClass(className, instructor, schedule, maxParticipants));
    }

    // Register Member For Class
    public bool RegisterForClass(int memberId, string className)
    {
        var member = members.FirstOrDefault(m => m.MemberId == memberId);
        var fitnessClass = classes.FirstOrDefault(c =>
                            c.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

        if (member == null || !member.IsActive || fitnessClass == null)
            return false;

        if (fitnessClass.AvailableSeats <= 0)
            return false;

        if (!fitnessClass.RegisteredMembers.Contains(memberId))
            fitnessClass.RegisteredMembers.Add(memberId);

        return true;
    }

    // Group Members By Membership Type
    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        return members
               .GroupBy(m => m.MembershipType)
               .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get Upcoming Classes (Next 7 Days)
    public List<FitnessClass> GetUpcomingClasses()
    {
        DateTime now = DateTime.Now;
        DateTime nextWeek = now.AddDays(7);

        return classes
               .Where(c => c.Schedule >= now && c.Schedule <= nextWeek)
               .OrderBy(c => c.Schedule)
               .ToList();
    }
}
class Program
{
    static void Main()
    {
        GymManager gym = new GymManager();

        // 1️ Add Members
        gym.AddMember("Rahul", "Basic", 3);
        gym.AddMember("Priya", "Premium", 6);
        gym.AddMember("Amit", "Platinum", 12);

        // 2️ Add Fitness Classes
        gym.AddClass("Yoga", "Anita", DateTime.Now.AddDays(2), 10);
        gym.AddClass("Zumba", "Rohit", DateTime.Now.AddDays(5), 8);
        gym.AddClass("HIIT", "Vikas", DateTime.Now.AddDays(10), 12);

        // 3️ Register Members
        Console.WriteLine("Registering Rahul for Yoga...");
        Console.WriteLine(gym.RegisterForClass(1, "Yoga") ? "Registered" : "Failed");

        // 4️ Group Members By Membership Type
        Console.WriteLine("\nMembers By Membership Type:");
        var grouped = gym.GroupMembersByMembershipType();

        foreach (var type in grouped)
        {
            Console.WriteLine($"\n{type.Key}");
            foreach (var member in type.Value)
            {
                Console.WriteLine($"{member.MemberId} - {member.Name} - Expiry: {member.ExpiryDate.ToShortDateString()}");
            }
        }

        // 5️ Upcoming Classes
        Console.WriteLine("\nUpcoming Classes:");
        var upcoming = gym.GetUpcomingClasses();

        foreach (var cls in upcoming)
        {
            Console.WriteLine($"{cls.ClassName} - {cls.Schedule} - Seats Left: {cls.AvailableSeats}");
        }
    }
}