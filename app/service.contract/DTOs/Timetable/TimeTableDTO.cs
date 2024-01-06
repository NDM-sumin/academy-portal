using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs
{
    public class TimeTableDTO
    {
        public TimeTableDTO()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeekDTO>();
        }
        public string WeekDay { get; set; } = null!;
        public virtual ICollection<SlotTimeTableAtWeekDTO> SlotTimeTableAtWeeks { get; set; }
    }
}