using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class ExamVM
    {
        public int ExamId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? GroupName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int Time { get; set; }
        public int GroupId { get; set; }
    }
}
