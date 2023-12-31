﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class FeeDetail : AppEntityDefaultKey
    {
        public FeeDetail()
        {
            Attendances = new HashSet<Attendance>();
        }
        public float Amount { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid SubjectId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class? Class { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; }

        public Guid StudentSemesterId { get; set; }
        [ForeignKey(nameof(StudentSemesterId))]
        public StudentSemester StudentSemester { get; set; } = null!;
    }
}
