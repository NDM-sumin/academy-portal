using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Student : Account
    {
        public Student()
        {
            StudentSemesters = new HashSet<StudentSemester>();
            Scores = new HashSet<Score>();
            Role = shared.Enums.Role.Student;
        }
        public Guid MajorId { get; set; }
        [ForeignKey(nameof(MajorId))]
        public virtual Major Major { get; set; } = null!;

        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }
    }
}
