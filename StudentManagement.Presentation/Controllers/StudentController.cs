using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Presentation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
