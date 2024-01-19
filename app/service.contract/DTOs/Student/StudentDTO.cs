using service.contract.DTOs.Major;
using service.contract.DTOs.StudentSemester;

namespace service.contract.DTOs.Student
{
    public class StudentDTO : AppEntityDefaultKeyDTO
    {
        public StudentDTO()
        {
            StudentSemesters = new HashSet<StudentSemesterDto>();
        }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string? Phone { get; set; }
        public Guid MajorId { get; set; }
        public MajorDTO Major { get; set; } = null!;
        public ICollection<StudentSemesterDto> StudentSemesters { get; set; }
    }
}
