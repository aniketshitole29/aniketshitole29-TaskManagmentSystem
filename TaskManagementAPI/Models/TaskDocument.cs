using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class TaskDocument
    {
        public int TaskDocumentId { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentData { get; set; }
        public int TaskId { get; set; } // Foreign key
        [ForeignKey("TaskId")]

        [NotMapped]
        public UserTask Task { get; set; } // Navigation property
    }
}
