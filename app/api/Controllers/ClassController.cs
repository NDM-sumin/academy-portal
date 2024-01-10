using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.Student;
using service.contract.DTOs.SubjectComponent;
using service.contract.IAppServices;
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
        public async Task<List<StudentAttendance>> GetAttendances(Guid classId,string dateTime)
        {
            return await (appCRUDService as IClassService).GetAttendancesByClass(classId, DateTime.Parse(dateTime));
        }

        [HttpGet("GetDates/{classId}")]
        public async Task<List<DateTime?>> GetDates(Guid classId)
        {
            return await (appCRUDService as IClassService).GetDates(classId);
        }
    }
}
