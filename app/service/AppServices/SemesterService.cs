using AutoMapper;
using domain;
using service.AppServices.Base;
using service.contract.DTOs.Semester;
using service.contract.IAppServices;
using repository.contract.IAppRepositories;
using Microsoft.EntityFrameworkCore;
namespace service.AppServices
{
    public class SemesterService : AppCRUDDefaultKeyService<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>, ISemesterService
    {
        public SemesterService(ISemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
        public SemesterDTO GetCurrentSemester(Guid studentId)
        {
            var data = base.Repository.Entities
                .Include(c => c.NextSemester)
                .FirstOrDefault(s => s.StudentSemesters.Any(ss => ss.StudentId == studentId && ss.SemesterId == s.Id && ss.IsNow == true));
            return Mapper.Map<SemesterDTO>(data!);
        }
    }
}
