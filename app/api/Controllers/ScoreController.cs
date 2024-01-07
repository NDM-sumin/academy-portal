using api.Controllers.Base;
using domain;
using service.contract.DTOs.Score;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class ScoreController : AppCRUDDefaultKeyController<ScoreDTO, CreateScoreDTO, UpdateScoreDTO, Score>
    {


        public ScoreController(IScoreService appCRUDService) : base(appCRUDService)
        {

        }
    }
}
