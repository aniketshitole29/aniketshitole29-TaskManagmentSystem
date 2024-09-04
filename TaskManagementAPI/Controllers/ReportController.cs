using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Service.IService;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("Weekly")]
        public async Task<IActionResult> GetWeeklyReport()
        {
            var report = await _reportRepository.GetWeeklyReportAsync();
            return Ok(report);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("Monthly")]
        public async Task<IActionResult> GetMonthlyReport()
        {
            var report = await _reportRepository.GetMonthlyReportAsync();
            return Ok(report);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("TeamPerformance/{teamId}")]
        public async Task<IActionResult> GetTeamPerformanceReport(int teamId)
        {
            var report = await _reportRepository.GetTeamPerformanceReportAsync(teamId);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }
    }
}
