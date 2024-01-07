


using service.contract.DTOs.Attendance;
using service.contract.DTOs.Slot;
using service.contract.DTOs.Timetable;
using service.contract.DTOs.Week;

namespace service.contract.DTOs.SlotTimeTableAtWeek
{
    public class SlotTimeTableAtWeekDTO : AppEntityDefaultKeyDTO
    {
        public SlotTimeTableAtWeekDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }
        public Guid SlotId { get; set; }
        public Guid TimetableId { get; set; }

        public Guid? WeekId { get; set; }
        public virtual SlotDTO Slot { get; set; } = null!;
        public virtual WeekDTO Week { get; set; } = null!;
        public virtual TimeTableDTO Timetable { get; set; } = null!;

        public virtual ICollection<AttendanceDTO> Attendances { get; set; }
    }
}