

using domain;
using service.contract.DTOs.Slot;
using service.contract.DTOs.SubjectComponent;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ISubjectComponentService : IAppCRUDDefaultKeyService<SubjectComponentDTO, SubjectComponent, SubjectComponent, SubjectComponent>
    {
        Task<List<SubjectComponentDTO>> GetByStudentAndSubject(Guid feeDetailId, Guid subjectId);
    }

}