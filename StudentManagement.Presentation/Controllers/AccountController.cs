using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;
using System.Text.Json;

namespace StudentManagement.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBL _accountBL;

        public AccountController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = _accountBL.Login(loginVM);
                if (user != null)
                {
                    string sessonObj = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("loginDeatils", sessonObj);
                    return RedirectToUser(user);
                }
            }
            return View();
        }

        private IActionResult RedirectToUser(LoginVM user)
        {
            if (user.Role==(int)EnumRoles.Admin)
            {
                return RedirectToAction("", "User");
            }
            else if (user.Role == (int)EnumRoles.Teacher)
            {
                return RedirectToAction("", "Exam");
            }
            else
            {
                return RedirectToAction("", "Student");
            }
        }
    }
}
