namespace service.contract.DTOs.Semester
{
    public class SemesterDTO : AppEntityDefaultKeyDTO
    {
        public SemesterDTO()
        {
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

/*
        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }*/
    }
}
