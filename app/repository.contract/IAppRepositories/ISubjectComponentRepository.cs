

using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface ISubjectComponentRepository : IAppGenericDefaultKeyRepository<SubjectComponent>
    {

        public Task CreateDefaultSubjectComponent(Guid subjectId);

    }
}