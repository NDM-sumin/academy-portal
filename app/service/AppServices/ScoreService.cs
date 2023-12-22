using AutoMapper;
using domain;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class ScoreService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Score>, IScoreService
    {
        public ScoreService(IAppGenericDefaultKeyRepository<Score> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
