using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Attendance
{
    public class AttendanceHistory
    {
        public List<domain.Attendance> Attendances { get; set; } = new List<domain.Attendance>();
        public domain.Teacher? Teacher { get; set; }
        public domain.Class? Class { get; set; }

    }
}
