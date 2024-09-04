namespace TaskManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // e.g., Admin, Manager, Employee
        public ICollection<UserTask> Tasks { get; set; } // Navigation property
    }
}
