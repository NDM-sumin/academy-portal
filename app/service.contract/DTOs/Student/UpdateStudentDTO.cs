using domain;
using service.contract.DTOs.Major;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Student
{
    public class UpdateStudentDTO : AppEntityDefaultKey
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string? Phone { get; set; }
        public Guid MajorId { get; set; }
        public MajorDTO Major { get; set; }
    }
}
