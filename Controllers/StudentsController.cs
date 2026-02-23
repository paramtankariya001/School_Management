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

        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            ViewData["Title"] = "Student Details - " + student.Name;
            return View(student);
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
            var existing = _context.Students.Find(student.Id);
            if (existing == null)
                return NotFound();

            // Update only the fields from the form
            existing.Name = student.Name;
            existing.Class = student.Class;
            existing.RollNo = student.RollNo;
            existing.Email = student.Email;
            existing.Phone = student.Phone;
            existing.DateOfBirth = student.DateOfBirth;
            existing.Gender = student.Gender;
            existing.Address = student.Address;
            // Username and Password remain unchanged if not provided

            if (ModelState.IsValid || (!string.IsNullOrEmpty(existing.Username) && !string.IsNullOrEmpty(existing.Password)))
            {
                _context.Students.Update(existing);
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
