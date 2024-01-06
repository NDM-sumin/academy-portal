using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class StudentSemesterRepository : AppGenericDefaultKeyRepository<StudentSemester>, IStudentSemesterRepository
    {
        public StudentSemesterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
