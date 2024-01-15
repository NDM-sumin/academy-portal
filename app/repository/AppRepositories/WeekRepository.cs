using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.AppRepositories
{
    public class WeekRepository : AppGenericDefaultKeyRepository<Week>, IWeekRepository
    {
        public WeekRepository(AppDbContext context) : base(context)
        {
        }
    }
}
