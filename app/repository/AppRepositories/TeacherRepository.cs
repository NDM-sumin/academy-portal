using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class TeacherRepository : AppGenericDefaultKeyRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Teacher> GetTeacherByClass(Guid? classId)
        {
            return Context.Classes.Include(c => c.Teacher).FirstOrDefault(c => c.Id.Equals(classId)).Teacher;
        }
    }
}
