using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Week : AppEntityDefaultKey
    {
        public Week()
        {
            Attendances = new HashSet<Attendance>();
        }
        public int WeekName { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
