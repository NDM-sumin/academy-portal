using domain;
using entityframework;
using repository.AppRepositories.Base;

namespace repository.AppRepositories
{
    public class TeacherRepository : AppGenericDefaultKeyRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
