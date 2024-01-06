

using domain;
using service.contract.DTOs.Slot;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ISlotService : IAppCRUDDefaultKeyService<SlotDTO, SlotDTO, SlotDTO, Slot>
    {

    }
}