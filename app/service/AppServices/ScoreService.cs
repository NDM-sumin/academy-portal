using AutoMapper;
using domain;
using repository.AppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Score;
using service.contract.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class ScoreService : AppCRUDDefaultKeyService<ScoreDTO, CreateScoreDTO, UpdateScoreDTO, Score>, IScoreService
    {
        public ScoreService(IScoreRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
