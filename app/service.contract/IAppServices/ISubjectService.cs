using domain;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ISubjectService : IAppCRUDDefaultKeyService<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {
        List<SubjectDTO> GetRegisterSubjects(Guid studentId);
        List<SubjectDTO> GetSubjects(Guid semesterId, Guid studentId);
    }
}
