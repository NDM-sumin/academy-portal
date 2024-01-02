using domain;
using service.contract.DTOs.Class;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IClassService : IAppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {
    }
}
