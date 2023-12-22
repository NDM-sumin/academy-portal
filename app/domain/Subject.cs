using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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
        public Guid SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public virtual Semester Semester { get; set; } = null!;
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }
        public virtual ICollection<SubjectComponent> SubjectComponents { get; set; }    
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
