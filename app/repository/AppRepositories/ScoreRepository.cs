using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class ScoreRepository : AppGenericDefaultKeyRepository<Score>, IScoreRepository
    {
        public ScoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
