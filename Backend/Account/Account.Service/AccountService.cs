﻿using System.Collections.Generic;
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
            var accountToUpdate = _mapper.Map<Domain.Account>(accountToUpdateDto);
            return await _unitOfWork.Accounts.Update(accountToUpdate);
        }

        public async Task AddNewAccount(AccountDto accountToCreateDto)
        {
            var accountToCreate = _mapper.Map<Domain.Account>(accountToCreateDto);
            await _unitOfWork.Accounts.Add(accountToCreate);
        }

        public async Task<IEnumerable<AccountDto>> SearchAccount(SearchAccount query)
        {
            await _unitOfWork.Accounts.GetWhere(x =>
                x.FirstName.Equals(query.FirstName) && x.LastName.Equals(query.LastName)
            );
            return null;
        }
    }
}
