using entityframework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericSingleKeyRepository<TEntity, TKey> : IAppGenericAbstractKeyRepository<TEntity, TKey>, IGenericSingleKeyRepository<AppDbContext, TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
    }
}
