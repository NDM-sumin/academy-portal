using domain;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.Student;
using service.contract.DTOs.Teacher;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ITeacherService : IAppCRUDDefaultKeyService<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>
    {
        Task<List<ClassDTO>> GetClassByTeacher(Guid teacherId);
        Task<List<TeacherTimetableDto>> GetTimeTable(Guid teacherId);
    }
}
