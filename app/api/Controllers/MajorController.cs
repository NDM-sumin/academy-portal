using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Major;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class MajorController : AppCRUDDefaultKeyController<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>
    {


        public MajorController(IMajorService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpGet("{id}/Subjects")]
        public async Task<List<SubjectDTO>> GetSubjectByMajor(Guid id)
        {
            var response = await (appCRUDService as IMajorService).GetSubjectByMajor(id);
            return response;
        }
    }
}
