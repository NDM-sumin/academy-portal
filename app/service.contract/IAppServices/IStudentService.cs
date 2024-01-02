using domain;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentService : IAppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO);
    }
}
