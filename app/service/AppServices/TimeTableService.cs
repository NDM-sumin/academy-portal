

using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class TimeTableService : AppCRUDDefaultKeyService<TimeTableDTO, TimeTableDTO, TimeTableDTO, Timetable>, ITimeTableService
    {
        public TimeTableService(ITimeTableRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}