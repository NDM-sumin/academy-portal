using domain;
using service.contract.DTOs.Score;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IScoreService : IAppCRUDDefaultKeyService<ScoreDTO, CreateScoreDTO, UpdateScoreDTO, Score>
    {
    }
}
