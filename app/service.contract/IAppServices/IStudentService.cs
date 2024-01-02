using domain;
using Microsoft.AspNetCore.Http;
using service.contract.DTOs.Account;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentService : IAppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        Task ImportStudentsFromExcel(IFormFile file);
        Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO);
    }
}
