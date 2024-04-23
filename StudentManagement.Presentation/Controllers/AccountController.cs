using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;
using System.Security.Claims;
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
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = _accountBL.Login(loginVM);
                if (user != null)
                {
                    string sessonObj = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("loginDeatils", sessonObj);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, loginVM.UserName!)
                    };
                    var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                    return RedirectToUser(user);
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToUser(LoginVM user)
        {
            if (user.Role==(int)EnumRoles.Admin)
            {
                return RedirectToAction("GetAllTeacher", "User");
            }
            else if (user.Role == (int)EnumRoles.Teacher)
            {
                return RedirectToAction("GetAllExam", "Exam");
            }
            else
            {
                return RedirectToAction("GetAllStudent", "Student");
            }
        }
    }
}
