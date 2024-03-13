using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
