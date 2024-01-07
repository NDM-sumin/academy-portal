using AutoMapper;
using domain;
using service.AppServices.Base;
using service.contract.DTOs.Semester;
using service.contract.IAppServices;
using repository.contract.IAppRepositories;
namespace service.AppServices
{
    public class SemesterService : AppCRUDDefaultKeyService<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>, ISemesterService
    {
        public SemesterService(ISemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        //public List<Semester> GetSemesterByStudent(Guid studentId)
        //{
        //    base.Repository.
        //}
    }
}
