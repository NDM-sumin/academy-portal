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
    public class MajorService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Major>, IMajorService
    {
        public MajorService(IAppGenericDefaultKeyRepository<Major> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
