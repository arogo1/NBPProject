using Microsoft.EntityFrameworkCore;

namespace Account.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        public DbSet<Domain.Account> Accounts { get; set; }
    }
}
