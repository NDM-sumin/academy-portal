using api.Controllers.Base;
using domain;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class TeacherController : AppCRUDDefaultKeyWithOdataController<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>
    {


        public TeacherController(ITeacherService appCRUDService) : base(appCRUDService)
        {

        }

    }
}
