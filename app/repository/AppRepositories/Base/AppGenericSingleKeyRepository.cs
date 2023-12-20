using entityframework;
using repository.contract.IAppRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.AppRepositories.Base
{
    public class AppGenericSingleKeyRepository<TEntity, TKey> : GenericSingleKeyRepository<AppDbContext, TEntity, TKey>, IAppGenericSingleKeyRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        public AppGenericSingleKeyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
