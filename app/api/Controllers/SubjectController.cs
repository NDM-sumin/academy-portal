using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.AppServices;
using service.contract.DTOs.Subject;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyWithOdataController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {


        public SubjectController(ISubjectService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpGet("GetRegisterSubject")]
        public async Task<List<SubjectDTO>> GetRegisterSubject(Guid studentId)
        {
            return (appCRUDService as ISubjectService).GetRegisterSubjects(studentId);
        }
    }
}
