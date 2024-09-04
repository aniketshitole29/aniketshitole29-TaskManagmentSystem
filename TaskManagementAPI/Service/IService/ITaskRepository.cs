using TaskManagementAPI.Models;

namespace TaskManagementAPI.Service.IService
{
    public interface ITaskRepository
    {
        Task<UserTask> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<UserTask>> GetTasksByEmployeeIdAsync(int employeeId);
        Task AddUserTaskAsync(UserTask task);
        Task UpdateUserTaskAsync(UserTask task);
        Task DeleteUserTaskAsync(int taskId);
    }
}
