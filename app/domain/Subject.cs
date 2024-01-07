using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class Subject : AppEntityDefaultKey
    {
        public Subject()
        {
            FeeDetails = new HashSet<FeeDetail>();
            SubjectComponents = new HashSet<SubjectComponent>();
            MajorSubjects = new HashSet<MajorSubject>();
        }
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }
        public virtual ICollection<SubjectComponent> SubjectComponents { get; set; }
    }
}
