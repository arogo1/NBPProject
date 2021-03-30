<<<<<<< HEAD
﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
=======
﻿using Account.Data.Interfaces;
>>>>>>> 5cdad436ed413194648759faa3ad8b9354f58207
using Account.Service.Interfaces;
using Account.Service.Models.DTO;
using Account.Service.Models.Query;
using Account.Service.Models.Request;

namespace Account.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("getAccountById")]
        public async Task<IHttpActionResult> GetAccountById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid account id");
                }

                var user = await _accountService.GetAccountById(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        [HttpGet]
        [Route("searchAccount")]
        public async Task<IHttpActionResult> SearchAccount([FromBody]SearchAccount query)
        {
            try
            {
                if (query == null) return BadRequest("Query cannot be empty");

                var accounts = await _accountService.SearchAccount(query);

                return Ok(accounts);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("updateAccount")]
        public async Task<IHttpActionResult> UpdatePassword(int id, [FromBody]UpdateAccountRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Request cannot be empty");
                if (id < 0) return BadRequest("Invalid id");

                var account = await _accountService.GetAccountById(id);
                if (account == null) return NotFound();

                account.FirstName = request.FirstName ?? account.FirstName;
                account.LastName = request.LastName ?? account.LastName;
                account.Username = request.UserName ?? account.Username;
                account.Password = request.Password ?? account.Password;

                await _accountService.UpdateAccount(account);

                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("createAccount")]
        public async Task<IHttpActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid request");
                var accountToCreate = new AccountDto()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Role = request.Role,
                    Username = request.Username,
                    Password = request.Password
                };

                await _accountService.AddNewAccount(accountToCreate);

                return Ok();

            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
