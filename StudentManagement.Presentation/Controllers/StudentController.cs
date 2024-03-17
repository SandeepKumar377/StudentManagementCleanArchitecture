using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBL _studentBL;

        public StudentController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentBL.CreateStudentAsync(studentVM);
                if (result>0)
                {
                    return RedirectToAction("GetAllStudent");
                }
            }
            return View();
        }
    }
}
