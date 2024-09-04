using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TaskName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [ForeignKey("Employee")]
        public int AssignedEmployeeId { get; set; }

        public Employee AssignedEmployee { get; set; }

        public bool IsCompleted => CompletedDate.HasValue;

        public ICollection<TaskNote> Notes { get; set; }

        public ICollection<TaskDocument> Documents { get; set; }

    }
}
