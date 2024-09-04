using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Service.IService;

namespace TaskManagementAPI.Service
{
    public class TaskDocumentRepository : ITaskDocumentRepository
    {
        private readonly AppDbContext _context;

        public TaskDocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDocument> GetTaskDocumentByIdAsync(int taskDocumentId)
        {
            return await _context.TaskDocuments
                                 .FirstOrDefaultAsync(td => td.TaskDocumentId == taskDocumentId);
        }

        public async Task<IEnumerable<TaskDocument>> GetDocumentsByTaskIdAsync(int taskId)
        {
            return await _context.TaskDocuments
                                 .Where(td => td.TaskId == taskId)
                                 .ToListAsync();
        }

        public async Task AddTaskDocumentAsync(TaskDocument taskDocument)
        {
            await _context.TaskDocuments.AddAsync(taskDocument);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskDocumentAsync(TaskDocument taskDocument)
        {
            _context.TaskDocuments.Update(taskDocument);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskDocumentAsync(int taskDocumentId)
        {
            var taskDocument = await _context.TaskDocuments.FindAsync(taskDocumentId);
            if (taskDocument != null)
            {
                _context.TaskDocuments.Remove(taskDocument);
                await _context.SaveChangesAsync();
            }
        }
    }
}
