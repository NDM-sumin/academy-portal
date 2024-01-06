using service.contract.DTOs.Major;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Subject;

namespace service.contract.DTOs.MajorSubject
{
    public class MajorSubjectDto : AppEntityDefaultKeyDTO
    {
        public Guid MajorId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual MajorDTO Major { get; set; } = null!;

        public virtual SubjectDTO Subject { get; set; } = null!;

        public Guid SemesterId { get; set; }
        public virtual SemesterDTO Semester { get; set; } = null!;
    }
}
