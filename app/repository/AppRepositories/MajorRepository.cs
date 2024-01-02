using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class MajorRepository : AppGenericDefaultKeyRepository<Major>, IMajorRepository
    {
        public MajorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Major> GetMajorByCode(string code) => await Entities.FirstOrDefaultAsync(m => m.MajorCode.Equals(code));

        public Major GetMajorByStudent(Guid studentId)
        {
            return Context.Students.FirstOrDefault(s => s.Id.Equals(studentId)).Major;
        }
    }
}
