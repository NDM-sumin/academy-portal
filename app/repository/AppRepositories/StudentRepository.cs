using domain;
using entityframework;
using repository.AppRepositories.Base;

namespace repository.AppRepositories
{
    public class StudentRepository : AppGenericDefaultKeyRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
