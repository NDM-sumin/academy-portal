﻿namespace service.contract.DTOs.Teacher
{
    public class TeacherDTO : AppEntityDefaultKeyDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string? Phone { get; set; }
    }
}
