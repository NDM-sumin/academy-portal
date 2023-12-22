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
            FeeDetails = new HashSet<FeeDetail>();
        }
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
