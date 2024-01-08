using domain;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IFeeDetailService : IAppCRUDDefaultKeyService<FeeDetailDTO, CreateFeeDetailDTO, CreateFeeDetailDTO, FeeDetail>
    {
        Task<List<FeeDetailDTO>> GetByStudent(Guid studentId, Guid semesterId);
        Task<(FeeDetailDTO, List<AttendanceDTO>)> GetByStudentAndSubject(Guid studentId, Guid semesterId, Guid subjectId);
    }
}
