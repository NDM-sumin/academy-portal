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
        private readonly ISemesterRepository _semesterRepository;
        public SemesterService(ISemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _semesterRepository = genericRepository;
        }

        public List<Semester> GetSemesterByStudent(Guid studentId)
        {
            return _semesterRepository.GetSemesterByStudent(studentId).Select(ss => ss.Semester).ToList();
        }
    }
}
