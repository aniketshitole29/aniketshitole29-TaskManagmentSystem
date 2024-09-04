using TaskManagementAPI.Models;

namespace TaskManagementAPI.Service.IService
{
    public interface ITaskDocumentRepository
    {
        Task<TaskDocument> GetTaskDocumentByIdAsync(int taskDocumentId);
        Task<IEnumerable<TaskDocument>> GetDocumentsByTaskIdAsync(int taskId);
        Task AddTaskDocumentAsync(TaskDocument taskDocument);
        Task UpdateTaskDocumentAsync(TaskDocument taskDocument);
        Task DeleteTaskDocumentAsync(int taskDocumentId);
    }
}
