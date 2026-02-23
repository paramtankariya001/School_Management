using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentPortalController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentPortalController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            var studentIdClaim = User.FindFirst("StudentId")?.Value;
            if (studentIdClaim == null) return RedirectToAction("StudentLogin", "Account");

            int studentId = int.Parse(studentIdClaim);
            var student = await _context.Students.FindAsync(studentId);

            if (student == null) return NotFound();

            ViewData["Title"] = "My Profile";
            return View(student);
        }

        public async Task<IActionResult> Fees()
        {
            var studentName = User.Identity?.Name;
            var fees = await _context.FeeRecords
                .Where(f => f.StudentName == studentName)
                .ToListAsync();

            ViewData["Title"] = "My Fee Records";
            return View(fees);
        }
    }
}
