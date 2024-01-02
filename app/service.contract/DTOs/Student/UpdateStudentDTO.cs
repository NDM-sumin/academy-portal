using service.contract.DTOs.Major;

namespace service.contract.DTOs.Student
{
    public class UpdateStudentDTO : AppEntityDefaultKeyDTO
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
