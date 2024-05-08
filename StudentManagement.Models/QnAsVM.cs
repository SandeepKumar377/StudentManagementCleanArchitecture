using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class QnAsVM
    {
        public int QnAsId { get; set; }
        public string? QuestionTitle { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public int SelectedAnswer { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
    }
}
