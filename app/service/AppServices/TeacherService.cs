using AutoMapper;
using domain;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class TeacherService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Teacher>, ITeacherService
    {
        public TeacherService(IAppGenericDefaultKeyRepository<Teacher> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
