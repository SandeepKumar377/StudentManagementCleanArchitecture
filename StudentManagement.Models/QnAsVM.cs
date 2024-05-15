using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class QnAsVM
    {
        public int QnAsId { get; set; }
        [Required]
        public string? QuestionTitle { get; set; }
        public int ExamId { get; set; }
        [Required]
        public int Answer { get; set; }
        public int SelectedAnswer { get; set; }
        [Required]
        public string? Option1 { get; set; }
        [Required]
        public string? Option2 { get; set; }
        [Required]
        public string? Option3 { get; set; }
        [Required]
        public string? Option4 { get; set; }
    }
}
