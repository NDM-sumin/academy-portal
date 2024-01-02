using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class SemesterRepository : AppGenericDefaultKeyRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
