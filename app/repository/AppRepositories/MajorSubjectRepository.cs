using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class MajorSubjectRepository : AppGenericDefaultKeyRepository<MajorSubject>, IMajorSubjectRepository
    {
        public MajorSubjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
