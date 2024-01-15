using domain;
using repository.contract.IAppRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.contract.IAppRepositories
{
    public interface IWeekRepository : IAppGenericDefaultKeyRepository<Week>
    {
    }
}
