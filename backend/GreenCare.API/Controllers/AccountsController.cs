using GreenCare.API.Data;
using GreenCare.API.Entities;
using GreenCare.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAccounts()
        {
            try
            {
                var accounts = await _context.Accounts
                    .Include(a => a.AppointmentCustomers)
                    .Include(a => a.AppointmentExperts)
                    .Include(a => a.PlantCareLogs)
                    .Include(a => a.Reviews)
                    .Include(a => a.Services)
                    .ToListAsync();

                var accountDtos = accounts.Select(account => new AccountDto
                {
                    Id = account.Id,
                    Email = account.Email,
                    Role = account.Role,
                    Name = account.Name,
                    Phone = account.Phone,
                    Address = account.Address,
                    AppointmentsAsCustomerCount = account.AppointmentCustomers.Count,
                    AppointmentsAsExpertCount = account.AppointmentExperts.Count,
                    PlantCareLogCount = account.PlantCareLogs.Count,
                    ReviewCount = account.Reviews.Count,
                    ServiceCount = account.Services.Count
                }).ToList();

                return Ok(accountDtos);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            try
            {
                var account = await _context.Accounts
                    .Include(a => a.AppointmentCustomers)
                    .Include(a => a.AppointmentExperts)
                    .Include(a => a.PlantCareLogs)
                    .Include(a => a.Reviews)
                    .Include(a => a.Services)
                    .FirstOrDefaultAsync(a => a.Id == id); // Find the specific account

                if (account == null)
                {
                    return NotFound(); // Account not found
                }

                var accountDto = new AccountDto
                {
                    Id = account.Id,
                    Email = account.Email,
                    Role = account.Role,
                    Name = account.Name,
                    Phone = account.Phone,
                    Address = account.Address,
                    AppointmentsAsCustomerCount = account.AppointmentCustomers.Count,
                    AppointmentsAsExpertCount = account.AppointmentExperts.Count,
                    PlantCareLogCount = account.PlantCareLogs.Count,
                    ReviewCount = account.Reviews.Count,
                    ServiceCount = account.Services.Count
                };

                return Ok(accountDto); // Return the DTO
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == loginRequest.Email);

                if (account == null || account.Password != loginRequest.Password)
                {
                    return NotFound("Invalid email or password.");
                }

                var accountDto = new AccountDto
                {
                    Id = account.Id,
                    Email = account.Email,
                    Role = account.Role,
                    Name = account.Name,
                    Phone = account.Phone,
                    Address = account.Address,
                    AppointmentsAsCustomerCount = account.AppointmentCustomers.Count,
                    AppointmentsAsExpertCount = account.AppointmentExperts.Count,
                    PlantCareLogCount = account.PlantCareLogs.Count,
                    ReviewCount = account.Reviews.Count,
                    ServiceCount = account.Services.Count
                };

                return Ok(accountDto); // Return the AccountDto
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register([FromBody] RegisterRequestDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (await _context.Accounts.AnyAsync(a => a.Email == registerRequest.Email))
                {
                    return Conflict("Account with this email already exists.");
                }

                var newAccount = new Account
                {
                    Email = registerRequest.Email,
                    Password = registerRequest.Password, // Again, NOT for production
                    Role = registerRequest.Role,
                    Name = registerRequest.Name,
                    Phone = registerRequest.Phone,
                    Address = registerRequest.Address
                };

                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync();

                // Map to DTO before returning
                var accountDto = new AccountDto
                {
                    Id = newAccount.Id,
                    Email = newAccount.Email,
                    Role = newAccount.Role,
                    Name = newAccount.Name,
                    Phone = newAccount.Phone,
                    Address = newAccount.Address,
                    AppointmentsAsCustomerCount = newAccount.AppointmentCustomers.Count,
                    AppointmentsAsExpertCount = newAccount.AppointmentExperts.Count,
                    PlantCareLogCount = newAccount.PlantCareLogs.Count,
                    ReviewCount = newAccount.Reviews.Count,
                    ServiceCount = newAccount.Services.Count
                };

                return CreatedAtAction(nameof(GetAccount), new { id = newAccount.Id }, accountDto);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "An error occurred while creating the account.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingAccount = await _context.Accounts.FindAsync(id);
                if (existingAccount == null)
                {
                    return NotFound("Account not found.");
                }

                // Update properties from the DTO
                existingAccount.Name = updateDto.Name;
                existingAccount.Email = updateDto.Email;
                existingAccount.Phone = updateDto.Phone;
                existingAccount.Address = updateDto.Address;
                if (!string.IsNullOrEmpty(updateDto.Role))
                {
                    existingAccount.Role = updateDto.Role;
                }

                // **Password Handling (CRITICAL)**
                if (!string.IsNullOrEmpty(updateDto.Password))
                {
                    // **In a production environment, you MUST hash the password here!**
                    // Use a robust hashing algorithm (e.g., bcrypt, Argon2) with a salt.
                    existingAccount.Password = updateDto.Password; // Insecure, for example only
                }

                if (await _context.Accounts.AnyAsync(a => a.Email == updateDto.Email && a.Id != id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);
                if (account == null)
                {
                    return NotFound(new { Message = "Account not found." });  // Consistent response format
                }

                if (account.Role == "admin")
                {
                    return BadRequest(new { Message = "Cannot delete an admin account." }); // Consistent format
                }

                // **Check for related data (optional but recommended)**
                if (account.AppointmentCustomers.Any() || account.AppointmentExperts.Any() ||
                    account.PlantCareLogs.Any() || account.Reviews.Any() || account.Services.Any())
                {
                    return Conflict(new { Message = "Cannot delete account with associated data." });
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