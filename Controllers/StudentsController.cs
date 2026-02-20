using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Data.SchoolDbContext _context;

        public StudentsController(Data.SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Students Management";
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add New Student";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            ViewData["Title"] = "Edit Student - " + student.Name;
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Models.Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            ViewData["Title"] = "Delete Student";
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
