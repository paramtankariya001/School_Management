using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly SchoolDbContext _context;

        public AccountController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StudentLogin()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Student")) return RedirectToAction("Profile", "StudentPortal");
                if (User.IsInRole("Teacher")) return RedirectToAction("Profile", "TeacherPortal");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentLogin(StudentLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Username == model.Username && s.Password == model.Password);

                if (student != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, student.Name),
                        new Claim(ClaimTypes.Role, "Student"),
                        new Claim("StudentId", student.Id.ToString()),
                        new Claim("RollNo", student.RollNo)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Profile", "StudentPortal");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult TeacherLogin()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Student")) return RedirectToAction("Profile", "StudentPortal");
                if (User.IsInRole("Teacher")) return RedirectToAction("Profile", "TeacherPortal");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TeacherLogin(StudentLoginViewModel model) // Reusing the same simple VM for simplicity
        {
            if (ModelState.IsValid)
            {
                var teacher = await _context.Teachers
                    .FirstOrDefaultAsync(t => t.Username == model.Username && t.Password == model.Password);

                if (teacher != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, teacher.Name),
                        new Claim(ClaimTypes.Role, "Teacher"),
                        new Claim("TeacherId", teacher.Id.ToString()),
                        new Claim("Department", teacher.Department)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Profile", "TeacherPortal");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
