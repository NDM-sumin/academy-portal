using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.StudentSemester;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class StudentSemesterService : AppCRUDDefaultKeyService<StudentSemesterDto, StudentSemesterDto, StudentSemesterDto, StudentSemester>, IStudentSemesterService
    {
        public StudentSemesterService(IStudentSemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
