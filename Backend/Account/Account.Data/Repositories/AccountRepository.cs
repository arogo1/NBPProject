using Account.Data.Interfaces;

namespace Account.Data.Repositories
{
    public class AccountRepository : GenericRepository<Domain.Account>, IAccountRepository
    {
        public AccountRepository(AccountContext context) : base(context) { }
    }
}
