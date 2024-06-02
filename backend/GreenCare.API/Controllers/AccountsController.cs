using GreenCare.API.Data;
using GreenCare.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public readonly GreenCareDbContext _context;

        public AccountsController(GreenCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);

                if (account == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(account);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("AddAccount")]
        public async Task<ActionResult<Account>> AddAccount(Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _context.Accounts.AnyAsync(a => a.Email == account.Email))
                {
                    return Conflict("Account with this email already exists.");
                }

                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while creating the account.");
            }
        }

        [HttpPut("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account updatedAccount)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingAccount = await _context.Accounts.FindAsync(id);
                if (existingAccount == null)
                {
                    return NotFound("Account not found.");
                }

                existingAccount.Name = updatedAccount.Name;
                existingAccount.Email = updatedAccount.Email;
                existingAccount.Phone = updatedAccount.Phone;
                existingAccount.Address = updatedAccount.Address;

                if (!string.IsNullOrEmpty(updatedAccount.Role))
                {
                    existingAccount.Role = updatedAccount.Role;
                }

                if (await _context.Accounts.AnyAsync(a => a.Email == updatedAccount.Email && a.Id != id))
                {
                    return Conflict("Account with this email already exists.");
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound("Account not found.");
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while updating the account.");
            }
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);
                if (account == null)
                {
                    return NotFound("Account not found.");
                }

                if (account.Role == "admin")
                {
                    return BadRequest("Cannot delete an admin account.");
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while deleting the account.");
            }
        }
    }
}
