using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountBL _accountBL;

        public UserController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                bool result = _accountBL.AddTeacher(userVM);
                if (result)
                {
                    return RedirectToAction("");
                }
            }
            return View();
        }
    }
}
