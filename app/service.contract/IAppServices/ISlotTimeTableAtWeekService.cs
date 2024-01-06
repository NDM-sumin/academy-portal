

using domain;
using service.contract.DTOs.Semester;
using service.contract.DTOs.SlotTimeTableAtWeek;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{

    public interface ISlotTimeTableAtWeekService : IAppCRUDDefaultKeyService<SlotTimeTableAtWeekDTO, SlotTimeTableAtWeekDTO, SlotTimeTableAtWeekDTO, SlotTimeTableAtWeek>
    {
        Task<List<SlotTimeTableAtWeekDTO>> GetSlotTimeTableAtWeeks(SemesterDTO currentSemester);
    }
}