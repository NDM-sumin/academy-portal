
using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Room;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class AttendanceService : AppCRUDDefaultKeyService<AttendanceDTO, AttendanceDTO, AttendanceDTO, Attendance>, IAttendanceService
    {
        public AttendanceService(IAttedanceRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<RoomDTO> GetRoomByFee(Guid feeId)
        {
            var result = (await base.Repository.Entities.Include(at => at.Room).Where(at => at.FeeDetailId == feeId).FirstOrDefaultAsync()).Room;
            return Mapper.Map<RoomDTO>(result);
        }
    }
}