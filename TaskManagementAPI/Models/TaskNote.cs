using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class TaskNote
    {
        [Key]
        public int TaskNoteId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskId { get; set; } // Foreign key
        [ForeignKey("TaskId")]

        [NotMapped]
        public UserTask Task { get; set; } // Navigation property

    }

}
