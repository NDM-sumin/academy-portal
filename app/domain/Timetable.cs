using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Timetable : AppEntityDefaultKey
    {
        public Timetable()
        {
            Attendances = new HashSet<Attendance>();
        }
        public string WeekDay { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
