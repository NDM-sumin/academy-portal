using domain;
using service.contract.DTOs.StudentSemester;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentSemesterService: IAppCRUDDefaultKeyService<StudentSemesterDto, StudentSemesterDto, StudentSemesterDto, StudentSemester>
    {
    }
}
