
using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class SlotRepository : AppGenericDefaultKeyRepository<Slot>, ISlotRepository
    {
        public SlotRepository(AppDbContext context) : base(context)
        {
        }
    }
}