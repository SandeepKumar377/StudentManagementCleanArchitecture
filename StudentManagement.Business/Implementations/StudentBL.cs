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
                    //GroupId = studentVM.GroupId,
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

        public PagingResultVM<StudentPagingVM> GetAllStudentWithPaging(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var studentList = _unitOfWork.GenericRepository<Student>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).Select(s => new StudentPagingVM()
                    {
                        StudentId=s.StudentId,
                        StudentName=s.StudentName,
                        StudentUserName=s.StudentUserName,
                        Contact=s.Contact,
                    }).ToList();
                var result = new PagingResultVM<StudentPagingVM>
                {
                    Data = studentList,
                    TotalItems = _unitOfWork.GenericRepository<Student>().GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {
                return new PagingResultVM<StudentPagingVM>();
            }
        }

        public IEnumerable<ResultVM> GetExamResults(int studentId)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool SetExamResult(AttendExamVM attendExamVM)
        {
            try
            {
                foreach (var item in attendExamVM.QnAsVMs!)
                {
                    ExamResult result = new ExamResult();
                    result.StudentId = attendExamVM.StudentId;
                    result.ExamId = item.ExamId;
                    //result.QnAsId = item.QnAsId;
                    result.Answer = item.Answer;
                    _unitOfWork.GenericRepository<ExamResult>().Add(result);
                    _unitOfWork.Save();
                    return true; 
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool SetGroupIdToStudent(GroupStudentVM groupStudentVM)
        {
            try
            {
                foreach (var item in groupStudentVM.CheckBoxTables!)
                {
                    var student = _unitOfWork.GenericRepository<Student>().GetById(item.Id);
                    if (item.IsChecked)
                    {
                        student.GroupId = groupStudentVM.GroupId;
                        _unitOfWork.GenericRepository<Student>().Update(student);
                    }
                    else
                    {
                        student.GroupId = null;
                    }
                }
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
