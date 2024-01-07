

using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class TimeTableRepository : AppGenericDefaultKeyRepository<Timetable>, ITimeTableRepository
    {
        public TimeTableRepository(AppDbContext context) : base(context)
        {
        }
    }
}