using service.contract.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Attendance
{
    public class StudentAttendance
    {
        public StudentDTO student { get; set; }
        public AttendanceDTO attendance { get; set; }
    }
}
