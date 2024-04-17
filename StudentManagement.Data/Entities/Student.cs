using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public required string StudentUserName { get; set; }
        public required string Password { get; set; }
        public string? Contact { get; set; }
        public string? CVFileUrl { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public virtual ICollection<ExamResult>? ExamResults { get; set; }
    }
}
