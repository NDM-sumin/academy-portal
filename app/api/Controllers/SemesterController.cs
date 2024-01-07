using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SemesterController : AppCRUDDefaultKeyController<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {


        public SemesterController(ISemesterService appCRUDService) : base(appCRUDService)
        {

        }

    }
}
