using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Classes Management";
            return View();
        }

        public IActionResult Details(string id)
        {
            ViewData["Title"] = "Class Details - " + id;
            return View(model: id);
        }
    }
}
