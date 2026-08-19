using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_Core_Database.Data;

namespace EF_Core_Database.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams
                .Include(t => t.Department)
                .Include(t => t.TeamMembers)
                .OrderBy(t => t.Name)
                .ToListAsync();

            return View(teams);
        }
    }
}