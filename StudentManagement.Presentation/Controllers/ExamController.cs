using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Controllers
{
    public class ExamController : Controller
    {
        private readonly IGroupBL _groupBL;
        private readonly IExamBL _examBL;

        public ExamController(IGroupBL groupBL, IExamBL examBL)
        {
            _groupBL = groupBL;
            _examBL = examBL;
        }
        public IActionResult GetAllExam(int pageNumber=1, int pageSize=10)
        {
            var examList = _examBL.GetAllExam(pageNumber, pageSize); 
            return View(examList);
        }

        [HttpGet]
        public IActionResult CreateExam()
        {
            var groups = _groupBL.GetAllGroup();
            ViewBag.AllGroup = new SelectList(groups, "GroupId", "GroupName");
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateExam(ExamVM examVM)
        {
            if (ModelState.IsValid)
            {
                var groups = _groupBL.GetAllGroup();
                ViewBag.AllGroup = new SelectList(groups, "GroupId", "GroupName");
                var result = _examBL.AddExam(examVM);
                if (result)
                {
                    return RedirectToAction("GetAllExam");
                }
            }           
            return View();
        }
    }
}
