using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Entities
{
    public class QnAs
    {
        public int QnAsId { get; set; }
        public string? QuestionTitle { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
        public virtual Exam? Exam { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}
