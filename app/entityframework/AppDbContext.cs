using domain;
using Microsoft.EntityFrameworkCore;

namespace entityframework
{
    public class AppDbContext : DbContext
    {


        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
