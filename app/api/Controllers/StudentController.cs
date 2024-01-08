using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.AppServices;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Score;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.DTOs.SubjectComponent;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class StudentController : AppCRUDDefaultKeyController<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        readonly IAttendanceService attendanceService;
        readonly IFeeDetailService feeDetailService;
        readonly ISubjectComponentService subjectComponentService;
        readonly IStudentSemesterService studentSemesterService;
        public StudentController(IStudentService appCRUDService,
        IAttendanceService attendanceService,
        IStudentSemesterService studentSemesterService,
        ISubjectComponentService subjectComponentService,
        IFeeDetailService feeDetailService) : base(appCRUDService)
        {
            this.attendanceService = attendanceService;
            this.feeDetailService = feeDetailService;
            this.subjectComponentService = subjectComponentService;
            this.studentSemesterService = studentSemesterService;

        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile? formFile)
        {

            await (appCRUDService as IStudentService).ImportStudentsFromExcel(formFile);
            return Ok();
        }


        [HttpGet("GetTimeTable")]
        public async Task<List<StudentTimetableDto>> GetTimeTable(Guid studentId)
        {
            return await (appCRUDService as IStudentService).GetTimeTable(studentId);
        }

        [HttpGet("GetAttendances/{studentId}/{semesterId}/{subjectId}")]
        public async Task<AttendanceHistory> GetAttendances(Guid studentId, Guid semesterId, Guid subjectId)
        {

            var (fee,attendance) = await feeDetailService.GetByStudentAndSubject(studentId, semesterId, subjectId);
            return new AttendanceHistory()
            {
                Attendances = attendance,
                Class = fee.Class,
                Teacher = fee.Class.Teacher
            };
        }

        [HttpGet("GetScores/{studentId}/{subjectId}")]
        public async Task<List<SubjectComponentDTO>> GetScores(Guid studentId, Guid subjectId)
        {

            return await subjectComponentService.GetByStudentAndSubject(studentId, subjectId);
        }

        [HttpGet("{studentId}/Semesters")]
        public async Task<IActionResult> GetSemesterByStudent(Guid studentId)
        {
            var data = await (appCRUDService as IStudentService).GetSemesterByStudent(studentId);
            return Ok(new
            {
                semesters = data.ToList(),
                current = (await studentSemesterService.GetCurrentSemester(studentId)).Semester  
            }) ;

        }

        [HttpPost("RegisterSubject/{studentId}/{subjectId}")]
        public async Task<IActionResult> RegisterSubject(Guid studentId, Guid subjectId)
        {
            await (appCRUDService as IStudentService).RegisterSubject(studentId, subjectId);
            return Ok();
        }

    }
}
