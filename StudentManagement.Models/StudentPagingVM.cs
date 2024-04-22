using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class StudentPagingVM
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentUserName { get; set; }
        public string? Contact { get; set; }
    }
}
