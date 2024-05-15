using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class GroupVM
    {
        public int GroupId { get; set; }
        [Required]
        public string? GroupName { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
