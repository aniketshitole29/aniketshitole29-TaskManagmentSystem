using TaskManagementAPI.Models;

namespace TaskManagementAPI.Service.IService
{
    public interface ITaskNoteRepository
    {
        Task<TaskNote> GetTaskNoteByIdAsync(int taskNoteId);
        Task<IEnumerable<TaskNote>> GetNotesByTaskIdAsync(int taskId);
        Task AddTaskNoteAsync(TaskNote taskNote);
        Task UpdateTaskNoteAsync(TaskNote taskNote);
        Task DeleteTaskNoteAsync(int taskNoteId);
    }
}
