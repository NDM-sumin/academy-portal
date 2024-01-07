using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class StudentController : AppCRUDDefaultKeyWithOdataController<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {
        readonly IAttendanceService attendanceService;
        readonly IFeeDetailService feeDetailService;

        public StudentController(IStudentService appCRUDService,
        IAttendanceService attendanceService,
        IFeeDetailService feeDetailService) : base(appCRUDService)
        {
            this.attendanceService = attendanceService;
            this.feeDetailService = feeDetailService;
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile? formFile)
        {

            await (appCRUDService as IStudentService).ImportStudentsFromExcel(formFile);
            return Ok();
        }

        [HttpPost("RegisterSubject")]
        public async Task<IActionResult> RegisterSubject([FromBody] CreateFeeDetailDTO createFeeDetailDTO)
        {
            await (appCRUDService as IStudentService).RegisterSubject(createFeeDetailDTO);
            return Ok();
        }

        [HttpGet("GetTimeTable")]
        public async Task<List<StudentTimetableDto>> GetTimeTable(Guid studentId)
        {
            return await (appCRUDService as IStudentService).GetTimeTable(studentId);
        }

        [HttpGet("GetAttendances")]
        public async Task<AttendanceHistory> GetAttendances(Guid studentId, Guid semesterId, Guid subjectId)
        {

            var fee = await feeDetailService.GetByStudentAndSubject(studentId, semesterId, subjectId);
            return new AttendanceHistory()
            {
                Attendances = fee.Attendances,
                Class = fee.Class,
                Teacher = fee.Class.Teacher
            };
        }

        
        [HttpGet("{studentId}/Semesters")]
        public async Task<List<SemesterDTO>> GetSemesterByStudent(Guid studentId)
        {
            var data = (await (appCRUDService as IStudentService).Get(studentId))
            .StudentSemesters.Select(ss => ss.Semester);
            return data.ToList();

        }
    }
}
