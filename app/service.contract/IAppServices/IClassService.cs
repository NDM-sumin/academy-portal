using domain;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.SubjectComponent;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IClassService : IAppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {
        Task<List<StudentAttendance>> GetAttendancesByClass(Guid classId, DateTime dateTime);
        Task<List<ClassDTO>> GetClassesByTeacher(Guid teacherId);
        Task<List<DateTime?>> GetDates(Guid classId);
        Task<List<StudentScoreDTO>> GetStudentsByClass(Guid classId);
        Task<List<SubjectComponentDTO>> GetSubjectComponentsByClass(Guid classId);
        Task<TeacherDTO> GetTeacher(Guid classId);
    }
}
