using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class GroupVM
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
    }
}
