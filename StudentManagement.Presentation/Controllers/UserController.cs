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
        public IActionResult GetAllTeacher(int pageNumber, int pageSize)
        {
            var result = _accountBL.GetAllTeacher(pageNumber, pageSize);
            return View(result);
        }
        
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserVM userVM)
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
