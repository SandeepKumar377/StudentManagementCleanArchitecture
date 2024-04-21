using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;
using StudentManagement.Presentation.Filters;

namespace StudentManagement.Presentation.Controllers
{
    [RoleAuthorize(1)]
    public class UserController : Controller
    {
        private readonly IAccountBL _accountBL;

        public UserController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }

        [HttpGet]
        public IActionResult GetAllTeacher(int pageNumber = 1, int pageSize = 10)
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
                    return RedirectToAction("GetAllTeacher");
                }
            }
            return View();
        }
    }
}
