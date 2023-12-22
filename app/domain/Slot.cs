using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Slot : AppEntityDefaultKey
    {
        public Slot()
        {
            Attendances = new HashSet<Attendance>();
        }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }
        public string SlotName { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
