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
    public class SubjectService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Subject>, ISubjectService
    {
        public SubjectService(IAppGenericDefaultKeyRepository<Subject> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
