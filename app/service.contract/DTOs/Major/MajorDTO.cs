using service.contract.DTOs.MajorSubject;
using service.contract.DTOs.Student;

namespace service.contract.DTOs.Major
{
    public class MajorDTO : AppEntityDefaultKeyDTO
    {
        public MajorDTO()
        {
            Students = new HashSet<StudentDTO>();
            MajorSubjects = new HashSet<MajorSubjectDto>();
        }
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
        public virtual ICollection<MajorSubjectDto> MajorSubjects { get; set; }
        public virtual ICollection<StudentDTO> Students { get; set; }
    }
}
