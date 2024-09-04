using TaskManagementAPI.Models;

namespace TaskManagementAPI.Service.IService
{
    public interface IReportRepository
    {
        Task<WeeklyReport> GetWeeklyReportAsync();
        Task<MonthlyReport> GetMonthlyReportAsync();
        Task<TeamPerformanceReport> GetTeamPerformanceReportAsync(int teamId);
    }
}
