using domain;
using entityframework;
using repository.AppRepositories.Base;

namespace repository.AppRepositories
{
    public class SubjectRepository : AppGenericDefaultKeyRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
