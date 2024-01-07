using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Room;
using service.contract.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class RoomService : AppCRUDDefaultKeyService<RoomDTO, CreateRoomDTO, CreateRoomDTO, Room>, IRoomService
    {
        public RoomService(IRoomRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
