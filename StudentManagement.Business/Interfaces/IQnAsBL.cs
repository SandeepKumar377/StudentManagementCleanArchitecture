using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IQnAsBL
    {
        bool CreateQnAs(QnAsVM qnAsVM);
        PagingResultVM<QnAsVM> GetAllQnAsWithPaging(int pageNumber, int pageSize);
    }
}
