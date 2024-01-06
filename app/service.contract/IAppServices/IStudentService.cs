using domain;
using Microsoft.AspNetCore.Http;
using service.contract.DTOs.Account;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IStudentService : IAppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        Task<List<Slot>> GetSlots();
        Task<List<TimeTableDTO>> GetTimeTable(Guid studentId);
        Task<List<Timetable>> GetTimetables();
        Task ImportStudentsFromExcel(IFormFile file);
        Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO);
        Task<AttendanceHistory> GetAttendances(Guid studentId, Guid semesterId, Guid subjectId);
    }
}
