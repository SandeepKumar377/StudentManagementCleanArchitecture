﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IExamBL
    {
        PagingResultVM<ExamVM> GetAllExamWithPaging(int pageNumber, int pageSize);
        bool AddExam(ExamVM examVM);
        IEnumerable<ExamVM> GetAllExamList();
    }
}
