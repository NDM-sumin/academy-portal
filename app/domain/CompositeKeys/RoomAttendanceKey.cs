using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.CompositeKeys
{
    public class RoomAttendanceKey
    {
        public Guid AttendanceId { get; set; }
        public Guid RoomId { get; set; }
        public Guid ClassId { get; set; }
    }
}
