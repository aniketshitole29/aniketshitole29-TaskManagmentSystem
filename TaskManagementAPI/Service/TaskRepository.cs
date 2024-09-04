using TaskManagementAPI.Service.IService;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI.Service
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks
                                 .Include(t => t.TaskId)
                                 .Include(t => t.TaskName)
                                 .FirstOrDefaultAsync(t => t.TaskId == taskId);
        }

        public async Task<IEnumerable<UserTask>> GetTasksByEmployeeIdAsync(int employeeId)
        {
            return await _context.Tasks
                                 .Where(t => t.AssignedEmployeeId == employeeId)
                                 .ToListAsync();
        }

        public async Task AddUserTaskAsync(UserTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserTaskAsync(UserTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
