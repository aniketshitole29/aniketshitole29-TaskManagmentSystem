using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Service.IService;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskNoteController : ControllerBase
    {
        private readonly ITaskNoteRepository _taskNoteRepository;

        public TaskNoteController(ITaskNoteRepository taskNoteRepository)
        {
            _taskNoteRepository = taskNoteRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskNoteById(int id)
        {
            var taskNote = await _taskNoteRepository.GetTaskNoteByIdAsync(id);
            if (taskNote == null)
            {
                return NotFound();
            }
            return Ok(taskNote);
        }

        [HttpGet("ByTask/{taskId}")]
        public async Task<IActionResult> GetNotesByTaskId(int taskId)
        {
            var taskNotes = await _taskNoteRepository.GetNotesByTaskIdAsync(taskId);
            return Ok(taskNotes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskNote([FromBody] TaskNote taskNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskNoteRepository.AddTaskNoteAsync(taskNote);
            return CreatedAtAction(nameof(GetTaskNoteById), new { id = taskNote.TaskNoteId }, taskNote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskNote(int id, [FromBody] TaskNote taskNote)
        {
            if (id != taskNote.TaskNoteId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _taskNoteRepository.UpdateTaskNoteAsync(taskNote);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskNote(int id)
        {
            await _taskNoteRepository.DeleteTaskNoteAsync(id);
            return NoContent();
        }
    }
}
