using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyWithOdataController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {


        public SubjectController(ISubjectService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpGet("GetRegisterableSubjects")]
        public async Task<List<SubjectDTO>> GetRegisterableSubjects()
        {
            return await (appCRUDService as ISubjectService).GetRegisterableSubjects(this.GetUserId());
        }
    }
}
