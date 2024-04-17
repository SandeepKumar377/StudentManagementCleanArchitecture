using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IStudentBL
    {
        Task<int> CreateStudentAsync(CreateStudentVM studentVM);
        IEnumerable<StudentVM> GetAllStudent();
        IEnumerable<ResultVM> GetExamResults(int studentId);
        bool SetExamResult(AttendExamVM attendExamVM);
        bool SetGroupIdToStudent(GroupStudentVM groupStudentVM);
    }
}
