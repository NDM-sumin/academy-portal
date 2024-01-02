using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class StudentSemester : AppEntityDefaultKey
    {

        public StudentSemester()
        {
            FeeDetails = new HashSet<FeeDetail>();
            IsNow = true;
        }


        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;


        public Guid SemesterId { get; set; }

        [ForeignKey(nameof(SemesterId))]
        public virtual Semester Semester { get; set; } = null!;

        public bool IsNow { get; set; }
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
