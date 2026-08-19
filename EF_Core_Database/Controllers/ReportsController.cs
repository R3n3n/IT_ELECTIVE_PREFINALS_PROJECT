using EF_Core_Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Database.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EmployeeWorkload()
        {
            var data = await _context.Employees
                .Where(e => e.IsActive)
                .Select(e => new EmployeeWorkloadViewModel
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    DepartmentName = e.Department.Name,
                    UnresolvedTicketCount = _context.TicketAssignments
                        .Count(a => a.EmployeeId == e.Id && a.UnassignedAt == null && !a.Ticket.Status.IsClosed)
                })
                .OrderBy(x => x.DepartmentName)
                .ThenBy(x => x.EmployeeName)
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> DepartmentWorkload()
        {
            var data = await _context.Departments
                .Select(d => new DepartmentWorkloadViewModel
                {
                    DepartmentName = d.Name,
                    EmployeeCount = _context.Employees.Count(e => e.DepartmentId == d.Id),
                    UnresolvedTicketCount = _context.TicketAssignments
                        .Count(a => a.UnassignedAt == null && !a.Ticket.Status.IsClosed && a.Employee.DepartmentId == d.Id)
                })
                .OrderBy(x => x.DepartmentName)
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> UnassignedTickets()
        {
            var unassigned = await _context.Tickets
                .Where(t => !t.TicketAssignments.Any(a => a.UnassignedAt == null))
                .Select(t => new UnassignedTicketViewModel
                {
                    TicketId = t.Id,
                    Subject = t.Subject,
                    CustomerName = t.Customer.CompanyName,
                    PriorityName = t.Priority.Name,
                    StatusName = t.Status.Name,
                    CreatedAt = t.CreatedAt
                })
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();

            return View(unassigned);
        }

        public async Task<IActionResult> MultipleAssigneeTickets()
        {
            var data = await _context.Tickets
                .Where(t => t.TicketAssignments.Count(a => a.UnassignedAt == null) > 1)
                .Select(t => new MultipleAssigneeViewModel
                {
                    TicketId = t.Id,
                    Subject = t.Subject,
                    ActiveAssigneesCount = t.TicketAssignments.Count(a => a.UnassignedAt == null),
                    Assignees = t.TicketAssignments
                        .Where(a => a.UnassignedAt == null)
                        .Select(a => a.Employee.FirstName + " " + a.Employee.LastName)
                })
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> PrimaryAssignee()
        {
            var data = await _context.Tickets
                .Select(t => new PrimaryAssigneeViewModel
                {
                    TicketId = t.Id,
                    Subject = t.Subject,
                    PrimaryAssignee = t.TicketAssignments
                        .Where(a => a.IsPrimary && a.UnassignedAt == null)
                        .Select(a => a.Employee.FirstName + " " + a.Employee.LastName)
                        .FirstOrDefault() ?? "Unassigned"
                })
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> CategoryHierarchy()
        {
            var categories = await _context.TicketCategories
                .Select(c => new CategoryHierarchyViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    ParentCategoryName = c.ParentCategory != null
                        ? c.ParentCategory.Name
                        : "Root"
                })
                .OrderBy(c => c.ParentCategoryName)
                .ThenBy(c => c.CategoryName)
                .ToListAsync();

            return View(categories);
        }

    }

    public class EmployeeWorkloadViewModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public int UnresolvedTicketCount { get; set; }
    }

    public class DepartmentWorkloadViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public int UnresolvedTicketCount { get; set; }
    }

    public class UnassignedTicketViewModel
    {
        public int TicketId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string PriorityName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class MultipleAssigneeViewModel
    {
        public int TicketId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int ActiveAssigneesCount { get; set; }

        public IEnumerable<string> Assignees { get; set; } = new List<string>();
    }

    public class PrimaryAssigneeViewModel
    {
        public int TicketId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string PrimaryAssignee { get; set; } = string.Empty;
    }

    public class CategoryHierarchyViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ParentCategoryName { get; set; } = "Root";
    }
}
