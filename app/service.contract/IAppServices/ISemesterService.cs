using domain;
using service.contract.DTOs.Account;
using service.contract.DTOs.Semester;
using service.contract.IAppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.IAppServices
{
    public interface ISemesterService : IAppCRUDDefaultKeyService<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {
    }
}
