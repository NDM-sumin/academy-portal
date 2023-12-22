using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Semester : AppEntityDefaultKey
    {
        public Semester()
        {
            Subjects = new HashSet<Subject>();
        }
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
