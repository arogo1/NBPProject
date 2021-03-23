using System;
namespace Account.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        int Complete();
    }
}
