using domain;
using service.contract.DTOs.Account;
using service.contract.DTOs.Class;
using service.contract.IAppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public interface IClassService : IAppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {
    }
}
