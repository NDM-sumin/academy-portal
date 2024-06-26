﻿using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
