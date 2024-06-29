using api.Dtos.Account;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsRepository _accountsRepo;

        public AccountsController(IAccountsRepository accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _accountsRepo.GetAllAsync();
            var usersDto = users.Select(u => new AccountDto { Email = u.Email, FirstName = u.FirstName, LastName = u.LastName });
            return Ok(usersDto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _accountsRepo.RegisterAsync(registerDto);

                if (result.IsSuccessful)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _accountsRepo.LoginAsync(loginDto);

                if (result.IsSuccessful)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{email}/change-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole([FromRoute] string email, string role)
        {
            var result = await _accountsRepo.ChangeRoleAsync(email, role);

            if (result.Succeeded)
            {
                return Ok(new { message = $"Role updated to {role} successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete([FromRoute] string email)
        {
            var result = await _accountsRepo.DeleteAsync(email);

            if (result.Succeeded)
            {
                return Ok(new { message = "User deleted successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailDto confirmEmailDto)
        {
            var result = await _accountsRepo.ConfirmEmailAsync(confirmEmailDto.UserId, confirmEmailDto.Token);

            if (result.Succeeded)
            {
                return Ok(new { message = "Email confirmed successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var result = await _accountsRepo.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.Token, resetPasswordDto.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Password reset successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update([FromRoute] string email, [FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _accountsRepo.UpdateAsync(email, updateUserDto);

            if (result.Succeeded)
            {
                return Ok(new { message = "User updated successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("{email}/role")]
        public async Task<IActionResult> GetUserRole([FromRoute] string email)
        {
            var user = await _accountsRepo.GetUserByEmailAsync(email);
            var role = await _accountsRepo.GetUserRoleAsync(user);

            return Ok(new { role });
        }

        [HttpPut("{email}/lock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LockUser([FromRoute] string email)
        {
            var result = await _accountsRepo.LockUserAsync(email);

            if (result.Succeeded)
            {
                return Ok(new { message = "User locked successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{email}/unlock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnlockUser([FromRoute] string email)
        {
            var result = await _accountsRepo.UnlockUserAsync(email);

            if (result.Succeeded)
            {
                return Ok(new { message = "User unlocked successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("{email}/id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserIdByEmail([FromRoute] string email)
        {
            var id = await _accountsRepo.GetUserIdByEmailAsync(email);

            return Ok(new { id });
        }

        [HttpGet("{id}/email")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserEmailById([FromRoute] string id)
        {
            var email = await _accountsRepo.GetUserEmailByIdAsync(id);

            return Ok(new { email });
        }
    }
}
