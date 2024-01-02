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

        public async Task AddRange(List<Student> students)
        {
            await base.Entities.AddRangeAsync(students);
        }
    }
}
