using System;
using System.Collections.Generic;
using System.Linq;

public class TaskItem
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }
    public string AssignedTo { get; set; }
}

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectManager { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}

public class TaskManager
{
    private List<Project> projects = new List<Project>();
    private int projectCounter = 1;
    private int taskCounter = 1;

    public void CreateProject(string name, string manager,
                             DateTime start, DateTime end)
    {
        projects.Add(new Project
        {
            ProjectId = projectCounter++,
            ProjectName = name,
            ProjectManager = manager,
            StartDate = start,
            EndDate = end
        });
    }

    public void AddTask(int projectId, string title, string description,
                        string priority, DateTime dueDate, string assignee)
    {
        var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
        if (project == null) return;

        project.Tasks.Add(new TaskItem
        {
            TaskId = taskCounter++,
            Title = title,
            Description = description,
            Priority = priority,
            Status = "ToDo",
            DueDate = dueDate,
            AssignedTo = assignee
        });
    }

    public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
    {
        return projects
            .SelectMany(p => p.Tasks)
            .GroupBy(t => t.Priority)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<TaskItem> GetOverdueTasks()
    {
        return projects
            .SelectMany(p => p.Tasks)
            .Where(t => t.DueDate < DateTime.Now && t.Status != "Completed")
            .ToList();
    }

    public List<TaskItem> GetTasksByAssignee(string assigneeName)
    {
        return projects
            .SelectMany(p => p.Tasks)
            .Where(t => t.AssignedTo.Equals(assigneeName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Project> GetAllProjects()
    {
        return projects;
    }
}

public class Program
{
    public static void Main()
    {
        TaskManager manager = new TaskManager();

        manager.CreateProject("Website Development", "Shubhankar",
            DateTime.Now, DateTime.Now.AddMonths(2));

        var projectId = manager.GetAllProjects()[0].ProjectId;

        manager.AddTask(projectId, "Design UI", "Create homepage UI",
            "High", DateTime.Now.AddDays(5), "Rahul");

        manager.AddTask(projectId, "Backend API", "Develop login API",
            "Medium", DateTime.Now.AddDays(-1), "Shubhankar");

        Console.WriteLine("Tasks Grouped By Priority:");
        var grouped = manager.GroupTasksByPriority();
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var task in group.Value)
            {
                Console.WriteLine($"{task.Title} - {task.AssignedTo}");
            }
        }

        Console.WriteLine("\nOverdue Tasks:");
        foreach (var task in manager.GetOverdueTasks())
        {
            Console.WriteLine(task.Title);
        }

        Console.WriteLine("\nTasks Assigned To Shubhankar:");
        foreach (var task in manager.GetTasksByAssignee("Shubhankar"))
        {
            Console.WriteLine(task.Title);
        }
    }
}
