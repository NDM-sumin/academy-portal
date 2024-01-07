using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Slot;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace api.Controllers
{
    public class TimeTableController : AppCRUDDefaultKeyWithOdataController<TimeTableDTO, TimeTableDTO, TimeTableDTO, Timetable>
    {
        public TimeTableController(ITimeTableService appCRUDService) : base(appCRUDService)
        {
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<TimeTableDTO>> GetAllList()
        {
            return await (appCRUDService as ITimeTableService).GetAll();
        }
    }
}