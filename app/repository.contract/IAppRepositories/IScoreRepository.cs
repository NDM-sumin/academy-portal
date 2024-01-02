using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IScoreRepository : IAppGenericDefaultKeyRepository<Score>
    {
        List<Subject> getOweSubject(Guid studentId);
    }
}
