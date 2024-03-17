using StudentManagement.Business.Interfaces;
using StudentManagement.Data.Entities;
using StudentManagement.Data.UnitOfWork;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Implementations
{
    public class StudentBL : IStudentBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> CreateStudentAsync(CreateStudentVM studentVM)
        {
            try
            {
                Student student = new Student()
                {
                    StudentName = studentVM.StudentName,
                    StudentUserName = studentVM.StudentUserName,
                    Password = studentVM.Password,
                    Contact = studentVM.Contact,
                    CVFileUrl = studentVM.CVFileUrl,
                    ProfilePictureUrl = studentVM.ProfilePictureUrl,
                    GroupId = studentVM.GroupId,
                };
                var result = await _unitOfWork.GenericRepository<Student>().AddAsync(student);
                _unitOfWork.Save();
                return result.StudentId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<StudentVM> GetAllStudent()
        {
            try
            {
                var students = _unitOfWork.GenericRepository<Student>().GetAll().Select(x => new StudentVM()
                {
                    StudentId = x.StudentId,
                    Password = x.Password,
                    StudentName = x.StudentName,
                    StudentUserName = x.StudentUserName,
                    Contact = x.Contact,
                    CVFileUrl = x.CVFileUrl,
                    ProfilePictureUrl = x.ProfilePictureUrl,
                    GroupId = x.GroupId,
                });
                return students!;
            }
            catch (Exception)
            {
                return new List<StudentVM>();
            }             
        }
    }
}
