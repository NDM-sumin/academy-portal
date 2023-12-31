using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.contract
{
    public interface IGenericSingleKeyRepository<TDbContext, TEntity, TKey> : IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
        where TKey : struct
    {
    }
}
