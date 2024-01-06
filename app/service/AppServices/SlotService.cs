using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Slot;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class SlotService : AppCRUDDefaultKeyService<SlotDTO, SlotDTO, SlotDTO, Slot>, ISlotService
    {
        public SlotService(ISlotRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}