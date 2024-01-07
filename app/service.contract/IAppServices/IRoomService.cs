using domain;
using service.contract.DTOs.Room;
using service.contract.IAppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.IAppServices
{
    public interface IRoomService : IAppCRUDDefaultKeyService<RoomDTO, CreateRoomDTO, CreateRoomDTO, Room>
    {
    }
}
