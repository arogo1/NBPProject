using Account.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebApi.Controllers
{
    [Route("account/")]
    [ApiController]
    public class AccountController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("")]
        public Domain.Account GetAccountById(int id)
        {
            return null;
        }
    }
}
