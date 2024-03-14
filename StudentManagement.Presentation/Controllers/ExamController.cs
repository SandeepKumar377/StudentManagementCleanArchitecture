using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Presentation.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
