using domain;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Room;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IAttendanceService : IAppCRUDDefaultKeyService<AttendanceDTO, AttendanceDTO, AttendanceDTO, Attendance>
    {
        Task<RoomDTO> GetRoomByFee(Guid feeId);
    }
}