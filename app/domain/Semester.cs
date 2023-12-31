using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Semester : AppEntityDefaultKey
    {
        public Semester()
        {
            StudentSemesters = new HashSet<StudentSemester>();
            MajorSubjects = new HashSet<MajorSubject>();
        }
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;

        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public Guid? PrevSemesterId { get; set; }
        public Semester? NextSemester { get; set; }

        public Semester? PrevSemester { get; set; }


        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }
    }
}
