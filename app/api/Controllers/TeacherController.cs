using api.Controllers.Base;
using domain;
using service.AppServices;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Teacher;

namespace api.Controllers
{
    public class TeacherController : AppCRUDDefaultKeyWithOdataController<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>
    {


        public TeacherController(ITeacherService appCRUDService) : base(appCRUDService)
        {

        }

    }
}
