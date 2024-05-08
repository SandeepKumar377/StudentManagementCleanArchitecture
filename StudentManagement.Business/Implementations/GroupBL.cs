using StudentManagement.Business.Interfaces;
using StudentManagement.Data;
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
    public class GroupBL : IGroupBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public GroupVM AddGroup(GroupVM groupVM)
        {
            try
            {
                Group group = new Group()
                {
                    GroupName = groupVM.GroupName,
                    Description = groupVM.Description,
                };
                _unitOfWork.GenericRepository<Group>().Add(group);
                _unitOfWork.Save();
                return groupVM;
            }
            catch (Exception)
            {
                return null!;
            }

        }

        public PagingResultVM<GroupVM> GetAllGroupWithPaging(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var groupList = _unitOfWork.GenericRepository<Group>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).Select(s => new GroupVM()
                    {
                        GroupId = s.GroupId,
                        GroupName = s.GroupName,
                        Description = s.Description,
                    }).ToList();
                var result = new PagingResultVM<GroupVM>
                {
                    Data = groupList,
                    TotalItems = _unitOfWork.GenericRepository<Group>().GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {
                return new PagingResultVM<GroupVM>();
            }
        }

        public IEnumerable<GroupVM> GetAllGroup()
        {
            try
            {
                var groupList = _unitOfWork.GenericRepository<Group>().GetAll()
                    .Select(s => new GroupVM()
                    {
                        GroupId = s.GroupId,
                        GroupName = s.GroupName,
                        Description = s.Description,
                    }).ToList();

                return groupList;
            }
            catch (Exception)
            {
                return new List<GroupVM>();
            }
        }

        public async Task<GroupVM> GetGroup(int groupId)
        {
            try
            {
                var group = await _unitOfWork.GenericRepository<Group>().GetByIdAsync(groupId);
                GroupVM groupVM = new GroupVM()
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName,
                    Description = group.Description,
                };
                return groupVM!;
            }
            catch (Exception)
            {
                return new GroupVM();
            }
        }
    }
}
