using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Service.IService;

namespace TaskManagementAPI.Service
{
    public class TaskNoteRepository: ITaskNoteRepository
    {
        private readonly AppDbContext _context;

        public TaskNoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskNote> GetTaskNoteByIdAsync(int taskNoteId)
        {
            return await _context.TaskNotes
                                 .FirstOrDefaultAsync(tn => tn.TaskNoteId == taskNoteId);
        }

        public async Task<IEnumerable<TaskNote>> GetNotesByTaskIdAsync(int taskId)
        {
            return await _context.TaskNotes
                                 .Where(tn => tn.TaskId == taskId)
                                 .ToListAsync();
        }

        public async Task AddTaskNoteAsync(TaskNote taskNote)
        {
            await _context.TaskNotes.AddAsync(taskNote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskNoteAsync(TaskNote taskNote)
        {
            _context.TaskNotes.Update(taskNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskNoteAsync(int taskNoteId)
        {
            var taskNote = await _context.TaskNotes.FindAsync(taskNoteId);
            if (taskNote != null)
            {
                _context.TaskNotes.Remove(taskNote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
