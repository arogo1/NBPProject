using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Data.Interfaces;
using Account.Service.Interfaces;
using Account.Service.Models.DTO;
using Account.Service.Models.Query;
using AutoMapper;

namespace Account.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAccountById(int id)
        {
            var result = await _unitOfWork.Accounts.GetByIdAsync(id);
            return _mapper.Map<AccountDto>(result);
        }

        public async Task<int> UpdateAccount(AccountDto accountToUpdateDto)
        {
            return await _unitOfWork.Accounts.Update(_mapper.Map<Domain.Account>(accountToUpdateDto));
        }

        public async Task AddNewAccount(AccountDto accountToCreateDto)
        {
            await _unitOfWork.Accounts.Add(_mapper.Map<Domain.Account>(accountToCreateDto));
        }

        public async Task<List<AccountDto>> SearchAccount(SearchAccount query)
        {
            var result = await _unitOfWork.Accounts.SearchAccount(query);
            return _mapper.Map<List<AccountDto>>(result);
        }

        public async Task<int> DeleteAccount(AccountDto accountDto)
        {
            return await _unitOfWork.Accounts.Remove(_mapper.Map<Domain.Account>(accountDto));
        }
    }
}
