using domain;

namespace service.contract.DTOs.Timetable
{
    public class TimeTableDTO
    {
        public domain.Subject Subject { get; set; } = null!;
        public domain.Room? Room { get; set; }
        public List<SlotTimeTableAtWeek> AtWeek { get; set; } = new List<SlotTimeTableAtWeek>();
    }
}
