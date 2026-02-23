using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherPortalController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherPortalController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            var teacherIdClaim = User.FindFirst("TeacherId")?.Value;
            if (teacherIdClaim == null) return RedirectToAction("TeacherLogin", "Account");

            int teacherId = int.Parse(teacherIdClaim);
            var teacher = await _context.Teachers.FindAsync(teacherId);

            if (teacher == null) return NotFound();

            ViewData["Title"] = "Teacher Profile";
            return View(teacher);
        }

        public async Task<IActionResult> Students()
        {
            // Simple logic: See all students for now, or filter by class if implemented
            var students = await _context.Students.ToListAsync();
            ViewData["Title"] = "My Students";
            return View(students);
        }
    }
}
