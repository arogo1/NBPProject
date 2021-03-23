using Account.Data.Interfaces;
using Account.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebApi.Controllers
{
    [Route("account/")]
    [ApiController]
    public class AccountController
    {
        private readonly IUnitOfWork _accountService;

        public AccountController(IUnitOfWork accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("getAccountById")]
        public Domain.Account GetAccountById(int id)
        {
            _accountService.Accounts.GetAll();
            return null;
        }


    }
}
