using domain;
using domain.shared.Exceptions;
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

        public Semester GetFirstSemester()
        {
            if(!this.Entities.Any()){
                throw new ClientException(5008);
            }
            return this.Entities.OrderBy(s => s.CreatedAt).FirstOrDefault()!;
        }
    }
}
