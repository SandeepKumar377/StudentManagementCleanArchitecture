using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupBL _groupBL;
        private readonly IStudentBL _studentBL;

        public GroupController(IGroupBL groupBL, IStudentBL studentBL)
        {
            _groupBL = groupBL;
            _studentBL = studentBL;
        }
        public IActionResult GetAllGroup(int pageNumber, int pageSize)
        {
            var groups = _groupBL.GetAllGroupWithPaging(pageNumber, pageSize);
            return View(groups);
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult CreateGroup(GroupVM groupVM)
        {
            if (ModelState.IsValid)
            {
                var result = _groupBL.AddGroup(groupVM);
                return RedirectToAction("GetAllGroup");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GroupDetails(int groupId)
        {
            GroupStudentVM groupStudentVM = new GroupStudentVM();
            var group = await _groupBL.GetGroup(groupId);
            var students = _studentBL.GetAllStudent();
            groupStudentVM.GroupId = group.GroupId;
            foreach (var student in students)
            {
                groupStudentVM.CheckBoxTables!.Add(new CheckBoxTable
                {
                    Id = student.StudentId,
                    Name = student.StudentName,
                    IsChecked = false
                });
            }
            return View(groupStudentVM);
        }
        
        [HttpPost]
        public IActionResult GroupDetails(GroupStudentVM groupStudentVM)
        {
            bool result = _studentBL.SetGroupIdToStudent(groupStudentVM);
            if (result)
            {
                return RedirectToAction("GetAllGroup");
            }
            return View(groupStudentVM);
        }
    }
}
