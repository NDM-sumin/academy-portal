using service.contract.DTOs.MajorSubject;
using service.contract.DTOs.StudentSemester;

namespace service.contract.DTOs.Semester
{
    public class SemesterDTO : AppEntityDefaultKeyDTO
    {
        public SemesterDTO()
        {
            StudentSemesters = new HashSet<StudentSemesterDto>();
            MajorSubjects = new HashSet<MajorSubjectDto>();
        }
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;

        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public Guid? PrevSemesterId { get; set; }
        public SemesterDTO? NextSemester { get; set; }

        public SemesterDTO? PrevSemester { get; set; }


        public virtual ICollection<StudentSemesterDto> StudentSemesters { get; set; }
        public virtual ICollection<MajorSubjectDto> MajorSubjects { get; set; }
    }
}
