﻿namespace StudentManagement.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
    }
}
