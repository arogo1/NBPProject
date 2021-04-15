using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Service.Models.Query;

namespace Account.Data.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Domain.Account>
    {
        Task<List<Domain.Account>> SearchAccount(SearchAccount request);
    }
}
