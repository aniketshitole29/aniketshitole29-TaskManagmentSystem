using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Service.IService;

namespace TaskManagementAPI.Service
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WeeklyReport> GetWeeklyReportAsync()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);

            var taskSummaries = await _context.Tasks
                .Where(t => t.CreatedDate >= oneWeekAgo)
                .Select(t => new TaskSummary
                {
                    TaskId = t.TaskId,
                    TaskName = t.TaskName,
                    AssignedEmployee = t.AssignedEmployee.FirstName,
                    DueDate = t.DueDate,
                    CompletedDate = t.CompletedDate
                }).ToListAsync();

            return new WeeklyReport
            {
                TotalTasksCompleted = taskSummaries.Count(t => t.CompletedDate != null),
                TotalTasksCreated = taskSummaries.Count(),
                TotalTasksOverdue = taskSummaries.Count(t => t.IsOverdue),
                TaskSummaries = taskSummaries
            };
        }

        public async Task<MonthlyReport> GetMonthlyReportAsync()
        {
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            var taskSummaries = await _context.Tasks
                .Where(t => t.CreatedDate >= oneMonthAgo)
                .Select(t => new TaskSummary
                {
                    TaskId = t.TaskId,
                    TaskName = t.TaskName,
                    AssignedEmployee = t.AssignedEmployee.FirstName,
                    DueDate = t.DueDate,
                    CompletedDate = t.CompletedDate
                }).ToListAsync();

            var employeePerformances = await _context.Employees
                .Select(e => new EmployeePerformance
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.FirstName,
                    TasksAssigned = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId && t.CreatedDate >= oneMonthAgo),
                    TasksCompleted = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId && t.CompletedDate != null && t.CreatedDate >= oneMonthAgo),
                    TasksOverdue = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId && t.DueDate < DateTime.Now && t.CompletedDate == null && t.CreatedDate >= oneMonthAgo)
                }).ToListAsync();

            return new MonthlyReport
            {
                TotalTasksCompleted = taskSummaries.Count(t => t.CompletedDate != null),
                TotalTasksCreated = taskSummaries.Count(),
                TotalTasksOverdue = taskSummaries.Count(t => t.IsOverdue),
                TaskSummaries = taskSummaries,
                EmployeePerformances = employeePerformances
            };
        }

        public async Task<TeamPerformanceReport> GetTeamPerformanceReportAsync(int teamId)
        {
            //var team = await _context.Teams.Include(t => t.Employees).FirstOrDefaultAsync(t => t.TeamId == teamId);
            //if (team == null) return null;

            //var employeePerformances = team.Employees.Select(e => new EmployeePerformance
            //{
            //    EmployeeId = e.EmployeeId,
            //    EmployeeName = e.Name,
            //    TasksAssigned = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId),
            //    TasksCompleted = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId && t.CompletedDate != null),
            //    TasksOverdue = _context.Tasks.Count(t => t.AssignedEmployeeId == e.EmployeeId && t.DueDate < DateTime.Now && t.CompletedDate == null)
            //}).ToList();

            //return new TeamPerformanceReport
            //{
            //    TeamId = team.TeamId,
            //    TeamName = team.Name,
            //    TotalTasksCompleted = employeePerformances.Sum(ep => ep.TasksCompleted),
            //    TotalTasksCreated = employeePerformances.Sum(ep => ep.TasksAssigned),
            //    TotalTasksOverdue = employeePerformances.Sum(ep => ep.TasksOverdue),
            //    EmployeePerformances = employeePerformances
            //};
            throw new NotImplementedException();
        }
    }
}
