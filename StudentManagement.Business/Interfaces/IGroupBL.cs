using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IGroupBL
    {
        PagingResultVM<GroupVM> GetAllGroupWithPaging(int pageNumber, int pageSize);
        IEnumerable<GroupVM> GetAllGroup();
        Task<GroupVM> GetGroup(int id);
        GroupVM AddGroup(GroupVM group);
    }
}
