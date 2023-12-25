using api.Controllers.Base;
using domain;
using service.AppServices;
using service.contract.DTOs.Subject;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyWithOdataController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {


        public SubjectController(ISubjectService appCRUDService) : base(appCRUDService)
        {

        }

    }
}
