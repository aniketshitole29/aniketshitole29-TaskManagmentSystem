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
    public class TaskDocumentController : ControllerBase
    {
        private readonly ITaskDocumentRepository _taskDocumentRepository;

        public TaskDocumentController(ITaskDocumentRepository taskDocumentRepository)
        {
            _taskDocumentRepository = taskDocumentRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskDocumentById(int id)
        {
            var taskDocument = await _taskDocumentRepository.GetTaskDocumentByIdAsync(id);
            if (taskDocument == null)
            {
                return NotFound();
            }
            return Ok(taskDocument);
        }

        [HttpGet("ByTask/{taskId}")]
        public async Task<IActionResult> GetDocumentsByTaskId(int taskId)
        {
            var taskDocuments = await _taskDocumentRepository.GetDocumentsByTaskIdAsync(taskId);
            return Ok(taskDocuments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskDocument([FromBody] TaskDocument taskDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskDocumentRepository.AddTaskDocumentAsync(taskDocument);
            return CreatedAtAction(nameof(GetTaskDocumentById), new { id = taskDocument.TaskDocumentId }, taskDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskDocument(int id, [FromBody] TaskDocument taskDocument)
        {
            if (id != taskDocument.TaskDocumentId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _taskDocumentRepository.UpdateTaskDocumentAsync(taskDocument);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDocument(int id)
        {
            await _taskDocumentRepository.DeleteTaskDocumentAsync(id);
            return NoContent();
        }
    }
}
