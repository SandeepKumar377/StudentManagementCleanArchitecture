using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class AttendExamVM
    {
        public int StudentId { get; set; }
        public string? ExamName { get; set; }
        public string? Message { get; set; }
        public List<QnAsVM>? QnAsVMs { get; set; }
    }
}
