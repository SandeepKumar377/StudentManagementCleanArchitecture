using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Business.Implementations;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;
using System.Drawing.Printing;

namespace StudentManagement.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBL _studentBL;
        private readonly IExamBL _examBL;
        private readonly IQnAsBL _qnAsBL;

        public StudentController(IStudentBL studentBL, 
            IExamBL examBL,
            IQnAsBL qnAsBL
            )
        {
            _studentBL = studentBL;
            _examBL = examBL;
            _qnAsBL = qnAsBL;
        }

        [HttpGet]
        public IActionResult GetAllStudent(int pageNumber = 1, int pageSize = 10)
        {
            var result = _studentBL.GetAllStudentWithPaging(pageNumber, pageSize);
            return View(result);
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

        [HttpGet]
        public IActionResult AttendExam()
        {
            AttendExamVM attendExamVM = new AttendExamVM();
            string loginObj = HttpContext.Session.GetString("loginDeatils")!;
            LoginVM loginVM = JsonConvert.DeserializeObject<LoginVM>(loginObj)!;
            if (loginVM == null)
            {
                attendExamVM.StudentId = loginVM!.Id;
                var todayExam = _examBL.GetAllExamList().Where(x => x.StartDate.Date == DateTime.Today.Date).FirstOrDefault();
                if (todayExam== null)
                {
                    attendExamVM.Message = "No Exam Scheduled today!";
                    return View(attendExamVM);
                }
                else
                {
                    if (!_qnAsBL.IsAttendExam(todayExam.ExamId, attendExamVM.StudentId))
                    {
                        attendExamVM.QnAsVMs= _qnAsBL.GetAllQnAsByExamId(todayExam.ExamId).ToList();
                        attendExamVM.ExamName = todayExam.Title;
                        return View(attendExamVM);
                    }
                    else
                    {
                        attendExamVM.Message = "You have already attended this exam!";
                        return View(attendExamVM);
                    }
                }
            }
            return RedirectToAction("Login", "Account");
        }
          
        [HttpPost]
        public IActionResult AttendExam(AttendExamVM attendExamVM)
        {
            bool result = _studentBL.SetExamResult(attendExamVM);
            return RedirectToAction("");
        }

        public IActionResult Result(int studentId)
        {
            var data = _studentBL.GetExamResults(studentId);
            return View(data);
        }
    }
}
