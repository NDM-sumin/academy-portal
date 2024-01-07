using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;

namespace service.contract.DTOs.StudentSemester
{
    public class StudentSemesterDto : AppEntityDefaultKeyDTO
    {
        public StudentSemesterDto()
        {
            FeeDetails = new HashSet<FeeDetailDTO>();
        }
        public Guid StudentId { get; set; }

        public virtual StudentDTO Student { get; set; } = null!;


        public Guid SemesterId { get; set; }
        public virtual SemesterDTO Semester { get; set; } = null!;

        public ICollection<FeeDetailDTO> FeeDetails { get; set; }
    }
}
