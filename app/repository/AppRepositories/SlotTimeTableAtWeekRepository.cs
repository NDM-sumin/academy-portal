

using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories{
    public class SlotTimeTableAtWeekRepository : AppGenericDefaultKeyRepository<SlotTimeTableAtWeek>, ISlotTimeTableAtWeekRepository
    {
        public SlotTimeTableAtWeekRepository(AppDbContext context) : base(context)
        {
        }
    }
}