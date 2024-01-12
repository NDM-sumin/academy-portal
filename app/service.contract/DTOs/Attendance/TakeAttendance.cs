using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Attendance
{
    public class TakeAttendance
    {
        public Guid AttendanceId { get; set; }
        public bool IsAttendance { get; set; }
    }
}
