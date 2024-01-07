
using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class SubjectComponentRepository : AppGenericDefaultKeyRepository<SubjectComponent>, ISubjectComponentRepository
    {
        public SubjectComponentRepository(AppDbContext context) : base(context)
        {
        }
    }
}