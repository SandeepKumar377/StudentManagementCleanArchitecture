using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IAccountBL
    {
        bool AddTeacher(UserVM userVM);
        LoginVM Login(LoginVM loginVM);
        PagingResultVM<TeacherVM> GetAllTeacher(int pageNumber, int pageSize);
    }
}
