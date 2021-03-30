using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Service.Models.DTO;
using Account.Service.Models.Query;

namespace Account.Service.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccountById(int id);
        Task<int> UpdateAccount(AccountDto accountToUpdateDto);
        Task AddNewAccount(AccountDto accountToCreateDto);
        Task<IEnumerable<AccountDto>> SearchAccount(SearchAccount query);
    }
}
