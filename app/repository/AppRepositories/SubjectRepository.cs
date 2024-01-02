using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;

namespace repository.AppRepositories
{
    public class SubjectRepository : AppGenericDefaultKeyRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }

        public List<MajorSubject> GetMajorSubjects(Guid majorId,Guid semesterId)
        {
            return Context.MajorSubjects.Include(ms => ms.Subject).Where(ms => ms.MajorId.Equals(majorId) && ms.SemesterId.Equals(semesterId)).ToList();
        }
    }
}
