using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string Instructor { get; set; }
    public int DurationWeeks { get; set; }
    public double Price { get; set; }
    public List<string> Modules { get; set; } = new List<string>();
}

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public double ProgressPercentage { get; set; }
}

public class StudentProgress
{
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public Dictionary<string, double> ModuleScores { get; set; } = new Dictionary<string, double>();
    public DateTime LastAccessed { get; set; }
}

public class LearningManager
{
    private List<Course> courses = new List<Course>();
    private List<Enrollment> enrollments = new List<Enrollment>();
    private List<StudentProgress> progressRecords = new List<StudentProgress>();
    private int enrollmentCounter = 1;

    public void AddCourse(string code, string name, string instructor,
                         int weeks, double price, List<string> modules)
    {
        courses.Add(new Course
        {
            CourseCode = code,
            CourseName = name,
            Instructor = instructor,
            DurationWeeks = weeks,
            Price = price,
            Modules = modules
        });
    }

    public bool EnrollStudent(string studentId, string courseCode)
    {
        var course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
        if (course == null) return false;

        enrollments.Add(new Enrollment
        {
            EnrollmentId = enrollmentCounter++,
            StudentId = studentId,
            CourseCode = courseCode,
            EnrollmentDate = DateTime.Now,
            ProgressPercentage = 0
        });

        progressRecords.Add(new StudentProgress
        {
            StudentId = studentId,
            CourseCode = courseCode,
            LastAccessed = DateTime.Now
        });

        return true;
    }

    public bool UpdateProgress(string studentId, string courseCode,
                              string module, double score)
    {
        var course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
        if (course == null || !course.Modules.Contains(module)) return false;

        var progress = progressRecords.FirstOrDefault(p =>
            p.StudentId == studentId && p.CourseCode == courseCode);

        if (progress == null) return false;

        progress.ModuleScores[module] = score;
        progress.LastAccessed = DateTime.Now;

        var enrollment = enrollments.FirstOrDefault(e =>
            e.StudentId == studentId && e.CourseCode == courseCode);

        if (enrollment != null)
        {
            enrollment.ProgressPercentage =
                (double)progress.ModuleScores.Count / course.Modules.Count * 100;
        }

        return true;
    }

    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        return courses
            .GroupBy(c => c.Instructor)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
    {
        return enrollments
            .Where(e => e.CourseCode == courseCode)
            .OrderByDescending(e => e.ProgressPercentage)
            .Take(count)
            .ToList();
    }

    public List<Course> GetAllCourses()
    {
        return courses;
    }
}

public class Program
{
    public static void Main()
    {
        LearningManager manager = new LearningManager();

        manager.AddCourse("DS101", "Data Science Basics", "Shubhankar",
            8, 4999, new List<string> { "Python", "Statistics", "ML Basics" });

        manager.EnrollStudent("S001", "DS101");
        manager.EnrollStudent("S002", "DS101");

        manager.UpdateProgress("S001", "DS101", "Python", 85);
        manager.UpdateProgress("S001", "DS101", "Statistics", 90);
        manager.UpdateProgress("S002", "DS101", "Python", 70);

        Console.WriteLine("Courses Grouped By Instructor:");
        var grouped = manager.GroupCoursesByInstructor();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var course in group.Value)
            {
                Console.WriteLine(course.CourseName);
            }
        }

        Console.WriteLine("\nTop Performing Students:");
        var topStudents = manager.GetTopPerformingStudents("DS101", 2);
        foreach (var student in topStudents)
        {
            Console.WriteLine($"{student.StudentId} - {student.ProgressPercentage}%");
        }
    }
}
