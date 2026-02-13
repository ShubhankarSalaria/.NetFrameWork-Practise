using System.Collections.Generic;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string GradeLevel { get; set; }
    public Dictionary<string, double> Subjects { get; set; }

    public Student(int id, string name, string gradeLevel)
    {
        StudentId = id;
        Name = name;
        GradeLevel = gradeLevel;
        Subjects = new Dictionary<string, double>();
    }
}

public class SchoolManager
{
    private List<Student> students = new List<Student>();
    private int studentCounter = 1;

    // Add Student
    public void AddStudent(string name, string gradeLevel)
    {
        Student s = new Student(studentCounter++, name, gradeLevel);
        students.Add(s);
    }

    // Add Grade (0 - 100)
    public void AddGrade(int studentId, string subject, double grade)
    {
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade. Must be between 0 and 100.");
            return;
        }

        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        student.Subjects[subject] = grade; // Adds or updates
    }

    // Group Students by Grade Level
    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        return students
               .GroupBy(s => s.GradeLevel)
               .ToSortedDictionary(g => g.Key, g => g.ToList());
    }

    // Calculate Student Average
    public double CalculateStudentAverage(int studentId)
    {
        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if (student == null || student.Subjects.Count == 0)
            return 0;

        return student.Subjects.Values.Average();
    }

    // Calculate Subject Averages
    public Dictionary<string, double> CalculateSubjectAverages()
    {
        Dictionary<string, List<double>> subjectGrades = new Dictionary<string, List<double>>();

        foreach (var student in students)
        {
            foreach (var subject in student.Subjects)
            {
                if (!subjectGrades.ContainsKey(subject.Key))
                    subjectGrades[subject.Key] = new List<double>();

                subjectGrades[subject.Key].Add(subject.Value);
            }
        }

        return subjectGrades.ToDictionary(
            s => s.Key,
            s => s.Value.Average()
        );
    }

    // Get Top Performers
    public List<Student> GetTopPerformers(int count)
    {
        return students
               .OrderByDescending(s => s.Subjects.Count == 0 ? 0 : s.Subjects.Values.Average())
               .Take(count)
               .ToList();
    }
}
public static class DictionaryExtensions
{
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<IGrouping<TKey, TValue>> source)
    {
        return new SortedDictionary<TKey, TValue>(
            source.ToDictionary(g => g.Key, g => g.First())
        );
    }
}

class Program
{
    static void Main()
    {
        SchoolManager school = new SchoolManager();

        // 1️ Add Students
        school.AddStudent("Rahul", "10th");
        school.AddStudent("Priya", "10th");
        school.AddStudent("Aman", "11th");

        // 2️ Add Grades
        school.AddGrade(1, "Math", 85);
        school.AddGrade(1, "Science", 90);

        school.AddGrade(2, "Math", 78);
        school.AddGrade(2, "Science", 82);

        school.AddGrade(3, "Math", 95);
        school.AddGrade(3, "Science", 88);

        // 3️ Group Students By Grade Level
        Console.WriteLine("\nStudents By Grade Level:");
        var grouped = school.GroupStudentsByGradeLevel();

        foreach (var grade in grouped)
        {
            Console.WriteLine($"\n{grade.Key}");
            foreach (var student in grade.Value)
            {
                Console.WriteLine($"{student.StudentId} - {student.Name}");
            }
        }

        // 4️ Student Average
        Console.WriteLine("\nRahul Average: " + school.CalculateStudentAverage(1));

        // 5️ Subject Average
        Console.WriteLine("\nSubject Averages:");
        var subjectAvg = school.CalculateSubjectAverages();

        foreach (var subject in subjectAvg)
        {
            Console.WriteLine($"{subject.Key} : {subject.Value}");
        }

        // 6️ Top Performers
        Console.WriteLine("\nTop Performers:");
        var top = school.GetTopPerformers(2);

        foreach (var student in top)
        {
            Console.WriteLine(student.Name);
        }
    }
}