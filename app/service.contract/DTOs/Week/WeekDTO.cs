

using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Week
{

    public class WeekDTO : AppEntityDefaultKeyDTO
    {
        public WeekDTO()
        {
        }
        public int WeekName { get; set; }
    }
}