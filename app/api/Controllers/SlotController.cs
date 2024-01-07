using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Slot;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace api.Controllers
{
    public class SlotController : AppCRUDDefaultKeyController<SlotDTO, SlotDTO, SlotDTO, Slot>
    {
        public SlotController(ISlotService appCRUDService) : base(appCRUDService)
        {
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<SlotDTO>> GetAllList()
        {
            return await (appCRUDService as ISlotService).GetAll();
        }


    }
}