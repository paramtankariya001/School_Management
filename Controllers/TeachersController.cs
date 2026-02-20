using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class TeachersController : Controller
    {
        private readonly Data.SchoolDbContext _context;

        public TeachersController(Data.SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Teachers Management";
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add New Teacher";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
                return NotFound();

            ViewData["Title"] = "Edit Teacher - " + teacher.Name;
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Models.Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
                return NotFound();

            ViewData["Title"] = "Delete Teacher";
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
