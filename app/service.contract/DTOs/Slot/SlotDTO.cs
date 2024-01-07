using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Slot
{
    public class SlotDTO
    {
        public SlotDTO()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeekDTO>();
        }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int SlotName { get; set; }
        public virtual ICollection<SlotTimeTableAtWeekDTO> SlotTimeTableAtWeeks { get; set; }
    }
}