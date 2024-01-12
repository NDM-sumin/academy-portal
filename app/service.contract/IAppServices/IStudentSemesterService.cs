using domain;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentSemesterService : IAppCRUDDefaultKeyService<StudentSemesterDto, UpdateStudentSemesterDto, UpdateStudentSemesterDto, StudentSemester>
    {
        Task<StudentSemesterDto> SetNextSemester(Guid studentId);
        Task<List<StudentSemesterDto>> SetNextSemester();
        Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId);
        Task<StudentSemesterDto> GetCurrentSemester(Guid studentId);

    }
}
