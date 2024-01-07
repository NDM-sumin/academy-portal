using api.Controllers.Base;
using domain;
using service.contract.DTOs.Room;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace api.Controllers
{
    public class RoomController : AppCRUDDefaultKeyController<RoomDTO, CreateRoomDTO, CreateRoomDTO, Room>
    {
        public RoomController(IRoomService appCRUDService) : base(appCRUDService)
        {
        }
    }
}
