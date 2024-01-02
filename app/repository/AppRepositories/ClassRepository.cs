using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class ClassRepository : AppGenericDefaultKeyRepository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context)
        {
        }
    }
}
