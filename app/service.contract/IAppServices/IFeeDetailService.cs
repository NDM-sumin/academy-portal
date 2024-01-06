using domain;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IFeeDetailService : IAppCRUDDefaultKeyService<FeeDetailDTO, CreateFeeDetailDTO, CreateFeeDetailDTO, FeeDetail>
    {
        List<SubjectDTO> GetFailedSubjects(Guid studentId);
    }
}
