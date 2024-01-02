using api.Controllers.Base;
using domain;
using service.contract.DTOs.Semester;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SemesterController : AppCRUDDefaultKeyWithOdataController<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {


        public SemesterController(ISemesterService appCRUDService) : base(appCRUDService)
        {

        }


    }
}
