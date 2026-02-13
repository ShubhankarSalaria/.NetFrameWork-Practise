public class Employee
{
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public DateTime JoiningDate { get; set; }

    public Employee(string id, string name, string dept, double salary, DateTime joiningDate)
    {
        EmployeeId = id;
        Name = name;
        Department = dept;
        Salary = salary;
        JoiningDate = joiningDate;
    }
}

public class HRManager
{
    private List<Employee> employees = new List<Employee>();
    private int employeeCounter = 1;

    // Add Employee
    public void AddEmployee(string name, string dept, double salary)
    {
        string id = "E" + employeeCounter.ToString("D3"); // E001 format
        employeeCounter++;

        Employee emp = new Employee(id, name, dept, salary, DateTime.Now);
        employees.Add(emp);
    }

    // Group Employees by Department
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        SortedDictionary<string, List<Employee>> grouped = new SortedDictionary<string, List<Employee>>();

        foreach (var emp in employees)
        {
            if (!grouped.ContainsKey(emp.Department))
                grouped[emp.Department] = new List<Employee>();

            grouped[emp.Department].Add(emp);
        }

        return grouped;
    }

    // Calculate Department Salary
    public double CalculateDepartmentSalary(string department)
    {
        return employees
               .Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
               .Sum(e => e.Salary);
    }

    // Employees Joined After Specific Date
    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        return employees
               .Where(e => e.JoiningDate > date)
               .ToList();
    }
}

class Program
{
    static void Main()
    {
        HRManager hr = new HRManager();

        // Adding employees
        hr.AddEmployee("Amit", "IT", 60000);
        hr.AddEmployee("Riya", "HR", 50000);
        hr.AddEmployee("Karan", "Sales", 45000);
        hr.AddEmployee("Sneha", "IT", 65000);

        // 1️ Department wise grouping
        var grouped = hr.GroupEmployeesByDepartment();

        Console.WriteLine("Employees By Department:");
        foreach (var dept in grouped)
        {
            Console.WriteLine($"\nDepartment: {dept.Key}");
            foreach (var emp in dept.Value)
            {
                Console.WriteLine($"{emp.EmployeeId} - {emp.Name} - {emp.Salary}");
            }
        }

        // 2️ Total salary of IT Department
        Console.WriteLine("\nTotal IT Salary: " + hr.CalculateDepartmentSalary("IT"));

        // 3️ Employees joined after date
        Console.WriteLine("\nEmployees Joined Recently:");
        var recent = hr.GetEmployeesJoinedAfter(DateTime.Now.AddMinutes(-1));

        foreach (var emp in recent)
        {
            Console.WriteLine(emp.Name);
        }
    }
}