using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class CreateStudentVM
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public required string StudentUserName { get; set; }
        public required string Password { get; set; }
        public string? Contact { get; set; }
        public IFormFile? CVFile { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? CVFileUrl { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int GroupId { get; set; }
    }
   
}
