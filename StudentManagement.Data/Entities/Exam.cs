using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public virtual ICollection<ExamResult>? ExamResults { get; set; }
        public virtual ICollection<QnAs>? QnAs { get; set; }
    }
}
