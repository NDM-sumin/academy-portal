using api.Controllers.Base;
using domain;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyWithOdataController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {


        public SubjectController(ISubjectService appCRUDService) : base(appCRUDService)
        {

        }

    }
}
