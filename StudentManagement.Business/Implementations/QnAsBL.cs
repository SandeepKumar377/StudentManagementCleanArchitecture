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
    public class QnAsBL : IQnAsBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public QnAsBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateQnAs(QnAsVM qnAsVM)
        {
            try
            {
                QnAs qnAs = new QnAs()
                {
                    QuestionTitle = qnAsVM.QuestionTitle,
                    ExamId = qnAsVM.ExamId,
                    Answer = qnAsVM.Answer,
                    Option1 = qnAsVM.Option1,
                    Option2 = qnAsVM.Option2,
                    Option3 = qnAsVM.Option3,
                    Option4 = qnAsVM.Option4,
                };
                _unitOfWork.GenericRepository<QnAs>().Add(qnAs);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<QnAsVM> GetAllQnAsByExamId(int examId)
        {
            var qnAs = _unitOfWork.GenericRepository<QnAs>().GetAll()
                .Where(x => x.ExamId == examId).Select(s => new QnAsVM()
                {
                    QuestionTitle = s.QuestionTitle,
                    ExamId = s.ExamId,
                    Answer = s.Answer,
                    QnAsId = s.QnAsId,
                    Option1 = s.Option1,
                    Option2 = s.Option2,
                    Option3 = s.Option3,
                    Option4 = s.Option4,
                }).ToList();
            return qnAs;

        }

        public PagingResultVM<QnAsVM> GetAllQnAsWithPaging(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var qnAsList = _unitOfWork.GenericRepository<QnAs>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).Select(s => new QnAsVM()
                    {
                        QuestionTitle = s.QuestionTitle,
                        ExamId = s.ExamId,
                        Answer = s.Answer,
                        QnAsId = s.QnAsId,
                        Option1 = s.Option1,
                        Option2 = s.Option2,
                        Option3 = s.Option3,
                        Option4 = s.Option4,
                    }).ToList();
                var result = new PagingResultVM<QnAsVM>
                {
                    Data = qnAsList,
                    TotalItems = _unitOfWork.GenericRepository<QnAs>().GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {
                return new PagingResultVM<QnAsVM>();
            }
        }

        public bool IsAttendExam(int examId, int studentId)
        {
            var result = _unitOfWork.GenericRepository<ExamResult>().GetAll()
                .Where(x => x.ExamId == examId && x.StudentId == studentId);
            return result==null?false: true;
        }
    }
}
