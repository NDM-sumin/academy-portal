using service.contract.DTOs.Class;
using service.contract.DTOs.Teacher;

namespace service.contract.DTOs.Attendance
{
    public class AttendanceHistory
    {
        public AttendanceHistory()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }
        public ICollection<AttendanceDTO> Attendances { get; set; }
        public TeacherDTO? Teacher { get; set; }
        public ClassDTO? Class { get; set; }

    }
}
