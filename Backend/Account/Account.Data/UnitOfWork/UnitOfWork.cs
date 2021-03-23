using Account.Data.Interfaces;
using Account.Data.Repositories;

namespace Account.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountContext _context;
        public UnitOfWork(AccountContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
        }
        public IAccountRepository Accounts { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
