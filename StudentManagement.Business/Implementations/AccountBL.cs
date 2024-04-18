using StudentManagement.Business.Interfaces;
using StudentManagement.Data.Entities;
using StudentManagement.Data.UnitOfWork;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Implementations
{
    public class AccountBL(IUnitOfWork unitOfWork) : IAccountBL
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public bool AddTeacher(UserVM userVM)
        {
            try
            {
                User user = new User()
                {
                    Name = userVM.Name,
                    UserName = userVM.UserName,
                    Password = userVM.Password,
                    Role = (int)EnumRoles.Teacher
                };
                _unitOfWork.GenericRepository<User>().Add(user);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public PagingResultVM<TeacherVM> GetAllTeacher(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var teacherList = _unitOfWork.GenericRepository<User>().GetAll()
                    .Where(x => x.Role == (int)EnumRoles.Teacher)
                    .Skip(excludeRecords).Take(pageSize).Select(s => new TeacherVM()
                    {
                        TeacherUserName = s.UserName,
                        TeacherName = s.Name,
                        Role = s.Role.ToString()
                    }).ToList();
                var result = new PagingResultVM<TeacherVM>
                {
                    Data = teacherList,
                    TotalItems = _unitOfWork.GenericRepository<User>().GetAll().Where(x => x.Role == (int)EnumRoles.Teacher).Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {
                return new PagingResultVM<TeacherVM>();
            }
        }

        public LoginVM Login(LoginVM loginVM)
        {
            if (loginVM.Role==(int)EnumRoles.Teacher || loginVM.Role == (int)EnumRoles.Admin)
            {
                var user = _unitOfWork.GenericRepository<User>().GetAll().FirstOrDefault(x => x.UserName == loginVM.UserName!.Trim() 
                && x.Password == loginVM.Password && x.Role == loginVM.Role);
                if (user != null)
                {
                    loginVM.Id = user.UserId;
                    loginVM.UserName = user.UserName;
                    return loginVM;
                }
            }else
            {
                var user = _unitOfWork.GenericRepository<Student>().GetAll().FirstOrDefault(x => x.StudentUserName == loginVM.UserName!.Trim() &&
                x.Password == loginVM.Password);
                if (user != null)
                {
                    loginVM.Id = user.StudentId;
                    loginVM.UserName = user.StudentUserName;
                    return loginVM;
                }
            }
           
            return null!;
        }
    }
}
