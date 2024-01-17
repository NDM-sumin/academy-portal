using service.contract.DTOs.SlotTimeTableAtWeek;

namespace service.contract.DTOs.Timetable
{
    public class TimeTableDTO: AppEntityDefaultKeyDTO
    {
        public TimeTableDTO()
        {
        }
        public string WeekDay { get; set; } = null!;
    }
}