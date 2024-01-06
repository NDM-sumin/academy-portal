using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class StudentController : AppCRUDDefaultKeyWithOdataController<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>
    {


        public StudentController(IStudentService appCRUDService) : base(appCRUDService)
        {

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
        public async Task<List<TimeTableDTO>> GetTimeTable(Guid studentId)
        {
            return await (appCRUDService as IStudentService).GetTimeTable(studentId);
        }

    }
}
