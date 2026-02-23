using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class FeesController : Controller
    {
        private readonly Data.SchoolDbContext _context;

        public FeesController(Data.SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Fees Management";
            var records = _context.FeeRecords.OrderByDescending(f => f.PaymentDate).ToList();
            return View(records);
        }

        [HttpGet]
        public IActionResult Collect()
        {
            ViewData["Title"] = "Collect Student Fee";
            return View();
        }

        [HttpPost]
        public IActionResult Collect(Models.FeeRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.FeeRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _context.FeeRecords.Find(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Models.FeeRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.FeeRecords.Update(record);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _context.FeeRecords.Find(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var record = _context.FeeRecords.Find(id);
            if (record != null)
            {
                _context.FeeRecords.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
