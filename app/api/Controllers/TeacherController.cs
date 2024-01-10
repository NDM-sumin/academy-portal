using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.AppServices;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Teacher;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class TeacherController : AppCRUDDefaultKeyController<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>
    {


        public TeacherController(ITeacherService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpGet("GetTimeTable")]
        public async Task<List<TeacherTimetableDto>> GetTimeTable(Guid teacherId)
        {
            return await (appCRUDService as ITeacherService).GetTimeTable(teacherId);
        }

    }
}
