using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Entities
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int StudentId { get; set; }
        //public int QnAsId { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Exam? Exam { get; set; }
        //public virtual QnAs? QnAs { get; set; }
    }
}
