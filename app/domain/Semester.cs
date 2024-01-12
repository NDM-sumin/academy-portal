namespace domain
{
    public class Semester : AppEntityDefaultKey
    {
        public Semester()
        {
            StudentSemesters = new HashSet<StudentSemester>();
            MajorSubjects = new HashSet<MajorSubject>();
            Classes = new HashSet<Class>();
        }
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;

        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public Guid? PrevSemesterId { get; set; }
        public virtual Semester? NextSemester { get; set; }

        public virtual Semester? PrevSemester { get; set; }


        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
