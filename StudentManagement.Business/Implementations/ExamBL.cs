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
    public class ExamBL : IExamBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool AddExam(ExamVM examVM)
        {
            try
            {
                Exam exam = new Exam()
                {
                    Title = examVM.Title,
                    Description = examVM.Description,
                    StartDate = examVM.StartDate,
                    Time = examVM.Time,
                    GroupId = examVM.GroupId,
                };
                _unitOfWork.GenericRepository<Exam>().Add(exam);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PagingResultVM<ExamVM> GetAllExamWithPaging(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var examList = _unitOfWork.GenericRepository<Exam>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).Select(s => new ExamVM()
                    {
                        ExamId=s.ExamId,
                        Title = s.Title,
                        Description = s.Description,
                        StartDate = s.StartDate,
                        Time = s.Time,
                        GroupId = s.GroupId,
                    }).ToList();
                var result = new PagingResultVM<ExamVM>
                {
                    Data = examList,
                    TotalItems = _unitOfWork.GenericRepository<User>().GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {
                return new PagingResultVM<ExamVM>();
            }
        }

        public IEnumerable<ExamVM> GetAllExamList()
        {
            try
            {
                var examList = _unitOfWork.GenericRepository<Exam>().GetAll().Select(x => new ExamVM()
                {
                    ExamId = x.ExamId,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    GroupId = x.GroupId,
                    Time = x.Time,
                    Title = x.Title,
                }).ToList();   
                return examList;
            }
            catch (Exception)
            {
                return new List<ExamVM>();  
            }          
        }
    }
}
