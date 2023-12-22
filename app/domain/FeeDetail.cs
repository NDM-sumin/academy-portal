using System;
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
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
