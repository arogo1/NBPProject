using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Account.Service.Interfaces;
using Account.Service.Models.DTO;
using Account.Service.Models.Query;
using Account.Service.Models.Request;
using Account.WebApi.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Account.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public AccountController(IAccountService accountService, IMapper mapper, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("getAccountById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid request");

                var account = await _accountService.Login(request.UserName, request.Password);
                string token = null;
                if (account != null)
                {
                    token = GenerateJwtToken(account);
                    if(!string.IsNullOrEmpty(token)) return Ok(new AuthResult() { Token = token, Success = true });
                }

                return BadRequest("Something went wrong");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GenerateJwtToken(AccountDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim("Id", user.Id),
                //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                //    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                //}),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
