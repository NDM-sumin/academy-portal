using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class FeeDetail : AppEntityDefaultKey
    {
        public FeeDetail()
        {
            Attendances = new HashSet<Attendance>(); 
            Scores = new HashSet<Score>();
        }
        public float Amount { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid PaymentTransactionId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class? Class { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; }

        public Guid StudentSemesterId { get; set; }
        [ForeignKey(nameof(StudentSemesterId))]
        public virtual StudentSemester StudentSemester { get; set; } = null!;
        [ForeignKey(nameof(PaymentTransactionId))]
        public virtual PaymentTransaction PaymentTransaction { get; set; } = null!;
        public virtual ICollection<Score> Scores { get; set; }
    }
}
