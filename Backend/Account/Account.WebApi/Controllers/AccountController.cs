using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Service.Interfaces;
using Account.Service.Models.DTO;
using Account.Service.Models.Query;
using Account.Service.Models.Request;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAccountById")]
        public async Task<ActionResult<AccountDto>> GetAccountById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid account id");
                }

                var acccount = await _accountService.GetAccountById(id);
                if (acccount == null)
                {
                    return NotFound();
                }

                return Ok(acccount);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        [Route("searchAccount")]
        public async Task<ActionResult<List<AccountDto>>> SearchAccount([FromQuery] SearchAccount query)
        {
            try
            {
                if (query == null) return BadRequest("Query cannot be empty");

                var accounts = await _accountService.SearchAccount(query);

                return Ok(accounts);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("updateAccount")]
        public async Task<ActionResult> UpdateAccount(int id, [FromBody] UpdateAccountRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Request cannot be empty");
                if (id < 0) return BadRequest("Invalid id");

                var account = await _accountService.GetAccountById(id);
                if (account == null) return NotFound();

                _mapper.Map(request, account);

                await _accountService.UpdateAccount(account);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        [HttpPost]
        [Route("createAccount")]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid request");

                await _accountService.AddNewAccount(_mapper.Map<AccountDto>(request));

                return Ok(request);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id");
                var account = await _accountService.GetAccountById(id);
                if (account == null) return NotFound();

                await _accountService.DeleteAccount(account);

                return NoContent();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
