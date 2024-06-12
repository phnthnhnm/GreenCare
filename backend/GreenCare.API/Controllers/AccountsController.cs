using GreenCare.API.DTOs;
using GreenCare.API.Services;
using GreenCare.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService) // Inject IAccountService
        {
            _accountService = accountService;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        // POST: api/Accounts/Login
        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _accountService.LoginAsync(loginRequest);
            if (account == null)
            {
                return NotFound("Invalid email or password.");
            }

            return Ok(account);
        }

        // POST: api/Accounts/Register
        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register([FromBody] RegisterRequestDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var account = await _accountService.RegisterAsync(registerRequest);
                return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
            }
            catch (DbUpdateException ex)
            {
                return Conflict("Account with this email already exists.");
            }
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountDto updateAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.UpdateAccountAsync(id, updateAccountDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateException)
            {
                return Conflict(); // Possible email conflict
            }
        }


        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex) // For admin delete or accounts with related data
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
