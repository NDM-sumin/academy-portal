using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Slot
{
    public class SlotDTO : AppEntityDefaultKeyDTO
    {
        public SlotDTO()
        {
        }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int SlotName { get; set; }
    }
}