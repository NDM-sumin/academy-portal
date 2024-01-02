using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class SubjectService : AppCRUDDefaultKeyService<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>, ISubjectService
    {
        public SubjectService(ISubjectRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
