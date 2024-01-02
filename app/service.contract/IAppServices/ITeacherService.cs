using domain;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ITeacherService : IAppCRUDDefaultKeyService<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>
    {
    }
}
