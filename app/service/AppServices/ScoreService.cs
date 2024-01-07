using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Score;
using service.contract.DTOs.SubjectComponent;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class ScoreService : AppCRUDDefaultKeyService<ScoreDTO, CreateScoreDTO, UpdateScoreDTO, Score>, IScoreService
    {
        public ScoreService(IScoreRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

    }
}
