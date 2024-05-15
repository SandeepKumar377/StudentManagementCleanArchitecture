using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Controllers
{
    public class QnAsController : Controller
    {
        private readonly IExamBL _examBL;
        private readonly IQnAsBL _qnAsBL;

        public QnAsController(IExamBL examBL, IQnAsBL qnAsBL)
        {
            _examBL = examBL;
            _qnAsBL = qnAsBL;
        }
        public IActionResult GetAllQnAsWithPaging(int pageNumber=1, int pageSize=10)
        {
            var qnAsData = _qnAsBL.GetAllQnAsWithPaging(pageNumber, pageSize);
            return View(qnAsData);
        }

        [HttpGet]
        public IActionResult CreateQnAs()
        {
            var examList = _examBL.GetAllExamList();
            ViewBag.ExamList = new SelectList(examList, "ExamId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult CreateQnAs(QnAsVM qnAsVM)
        {
            if (ModelState.IsValid)
            {
                var result = _qnAsBL.CreateQnAs(qnAsVM);
                if (result)
                {
                    return RedirectToAction("GetAllQnAsWithPaging");
                }
            }           
            return View();
        }
        
      
    }
}
