using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;

namespace service.contract.DTOs.StudentSemester
{
    public class UpdateStudentSemesterDto : AppEntityDefaultKeyDTO
    {
        public UpdateStudentSemesterDto()
        {
        }
        public Guid StudentId { get; set; }
        public Guid SemesterId { get; set; }
        public bool IsNow { get; set; }

    }
}
