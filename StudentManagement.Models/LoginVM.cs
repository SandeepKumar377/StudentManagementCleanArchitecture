using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class LoginVM
    {
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public int Role { get; set; }
    }
}
