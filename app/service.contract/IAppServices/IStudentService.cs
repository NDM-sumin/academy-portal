using domain;
using Microsoft.AspNetCore.Http;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentService : IAppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        List<SubjectDTO> GetFailedSubjects(Guid studentId);
        Task<List<StudentTimetableDto>> GetTimeTable(Guid studentId);
        Task ImportStudentsFromExcel(IFormFile file);
        Task RegisterSubject(Guid studentId, Guid subjectId);
        Task<List<SemesterDTO>> GetSemesterByStudent(Guid studentId);
    }
}
