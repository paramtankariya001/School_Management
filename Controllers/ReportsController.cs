using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Reports & Analytics";
            return View();
        }
    }
}
