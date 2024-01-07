


using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Room;
using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Attendance
{
    public class AttendanceDTO : AppEntityDefaultKeyDTO
    {
        public Guid RoomId { get; set; }
        public Guid SlotTimeTableAtWeekId { get; set; }
        public Guid FeeDetailId { get; set; }
        public bool? IsAttendance { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
        public virtual RoomDTO Room { get; set; } = null!;
        public virtual SlotTimeTableAtWeekDTO SlotTimeTableAtWeek { get; set; } = null!;
        public virtual FeeDetailDTO FeeDetail { get; set; } = null!;
    }
}