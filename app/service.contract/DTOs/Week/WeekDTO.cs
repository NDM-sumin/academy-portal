

using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Week
{

    public class WeekDTO : AppEntityDefaultKeyDTO
    {
        public WeekDTO()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeekDTO>();
        }
        public int WeekName { get; set; }
        public virtual ICollection<SlotTimeTableAtWeekDTO> SlotTimeTableAtWeeks { get; set; }
    }
}