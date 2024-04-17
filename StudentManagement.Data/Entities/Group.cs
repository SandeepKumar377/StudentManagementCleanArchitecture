using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Exam>? Exams { get; set; }
    }
}
