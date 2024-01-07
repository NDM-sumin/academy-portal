using service.contract.DTOs.Attendance;

namespace service.contract.DTOs.Room
{
    public class RoomDTO : AppEntityDefaultKeyDTO
    {
        public RoomDTO()
        {
            RoomAttendances = new HashSet<AttendanceDTO>();
        }
        public string RoomCode { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<AttendanceDTO> RoomAttendances { get; set; }
    }
}
