
using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class AttendanceService : AppCRUDDefaultKeyService<AttendanceDTO, AttendanceDTO, AttendanceDTO, Attendance>, IAttendanceService
    {
        public AttendanceService(IAttedanceRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}