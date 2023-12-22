using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class RoomAttendance : AppEntityDefaultKey
    {
        public Guid RoomId { get; set; }
        public Guid ClassId { get; set; }
        public Guid AttendanceId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; } = null!;
        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;
        [ForeignKey(nameof(AttendanceId))]
        public virtual Attendance Attendance { get; set; } = null!;
    }
}
