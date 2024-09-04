namespace TaskManagementAPI.Models
{
    public class Report
    {
        public int TotalTasksCompleted { get; set; }
        public int TotalTasksCreated { get; set; }
        public int TotalTasksOverdue { get; set; }
    }
    public class TaskSummary
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string AssignedEmployee { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsOverdue => DueDate < DateTime.Now && CompletedDate == null;
    }
    public class EmployeePerformance
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TasksCompleted { get; set; }
        public int TasksAssigned { get; set; }
        public int TasksOverdue { get; set; }
    }

    public class WeeklyReport : Report
    {
        
        public IEnumerable<TaskSummary> TaskSummaries { get; set; }
    }
    public class MonthlyReport : Report
    {
        public IEnumerable<TaskSummary> TaskSummaries { get; set; }
        public IEnumerable<EmployeePerformance> EmployeePerformances { get; set; }
    }
    public class TeamPerformanceReport : Report
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public IEnumerable<EmployeePerformance> EmployeePerformances { get; set; }
    }


}
