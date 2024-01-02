using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class MajorRepository : AppGenericDefaultKeyRepository<Major>, IMajorRepository
    {
        public MajorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
