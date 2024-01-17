using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.Student;
using service.contract.DTOs.SubjectComponent;
using service.contract.IAppServices;
using System.Globalization;
using System.Net;

namespace api.Controllers
{
    public class ClassController : AppCRUDDefaultKeyController<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {

        readonly ITeacherService teacherService;
        public ClassController(IClassService appCRUDService, ITeacherService teacherService) : base(appCRUDService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet("GetClasses/{teacherId}")]
        public async Task<List<ClassDTO>> GetClasses(Guid teacherId)
        {
            return await teacherService.GetClassByTeacher(teacherId);
        }

        [HttpGet("GetStudents/{classId}")]
        public async Task<List<StudentScoreDTO>> GetStudents(Guid classId)
        {
            return await (appCRUDService as IClassService).GetStudentsByClass(classId);
        }

        [HttpGet("GetSubjectComponents/{classId}")]
        public async Task<List<SubjectComponentDTO>> GetSubjectComponents(Guid classId)
        {
            return await (appCRUDService as IClassService).GetSubjectComponentsByClass(classId);
        }

        [HttpGet("GetAttendances/{classId}")]
        public async Task<List<StudentAttendance>> GetAttendances(Guid classId, string dateTime)
        {
            var date = DateTime.ParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return await (appCRUDService as IClassService).GetAttendancesByClass(classId, date);
        }

        [HttpGet("GetDates/{classId}")]
        public async Task<List<DateTime?>> GetDates(Guid classId)
        {
            return await (appCRUDService as IClassService).GetDates(classId);
        }

        [HttpPost("SaveAttendance")]
        public async Task<IActionResult> SaveAttendance(string attendances)
        {
            var result = JsonConvert.DeserializeObject<List<TakeAttendance>>(attendances);
            await (appCRUDService as IClassService).SaveAttendance(result);
            return Ok();
        }

        [HttpPost("SaveScores")]
        public async Task<IActionResult> SaveScores(string scores)
        {
            var result = JsonConvert.DeserializeObject<List<TakeScore>>(scores);
            await (appCRUDService as IClassService).SaveScores(result);
            return Ok();
        }

        [HttpPost("ClassForNewSemester")]
        public async Task<IActionResult> ClassForNewSemester()
        {
            await (appCRUDService as IClassService).ClassForNewSemester();
            return Ok();
        }

        [HttpGet("GetClassInformation/{classId}")]
        public async Task<ClassInformation> GetClassInformation(Guid classId)
        {
            return await (appCRUDService as IClassService).GetClassInformation(classId);
        }

    }
}
