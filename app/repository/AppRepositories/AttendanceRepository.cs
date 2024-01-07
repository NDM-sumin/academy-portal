

using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class AttendanceRepository : AppGenericDefaultKeyRepository<Attendance>, IAttedanceRepository
    {
        public AttendanceRepository(AppDbContext context) : base(context)
        {
        }
    }
}