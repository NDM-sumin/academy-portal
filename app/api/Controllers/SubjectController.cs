using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyWithOdataController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {
        IStudentSemesterService studentSemesterService;


        public SubjectController(ISubjectService appCRUDService,
        IStudentSemesterService studentSemesterService) : base(appCRUDService)
        {
            this.studentSemesterService = studentSemesterService;

        }

        [HttpGet("GetRegisterableSubjects")]
        public async Task<List<SubjectDTO>> GetRegisterableSubjects()
        {
            return await (appCRUDService as ISubjectService).GetRegisterableSubjects(this.GetUserId());
        }

        [HttpGet("GetSubjects")]
        public async Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId)
        {
            return await studentSemesterService.GetSubjects(semesterId, studentId);
        }
    }
}
