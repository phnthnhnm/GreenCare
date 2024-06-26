using api.Dtos.Account;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsRepository _accountsRepo;

        public AccountsController(IAccountsRepository accountsRepo)
        {
            _accountsRepo = accountsRepo;
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

        // [HttpPost("change-role")]
        // public async Task<IActionResult> ChangeUserRole(string userId, string newRole)
        // {
        //     var user = await _userManager.FindByIdAsync(userId);
        //     if (user == null)
        //     {
        //         return NotFound("User not found");
        //     }

        //     var currentRoles = await _userManager.GetRolesAsync(user);
        //     await _userManager.RemoveFromRolesAsync(user, currentRoles);

        //     var result = await _userManager.AddToRoleAsync(user, newRole);
        //     if (result.Succeeded)
        //     {
        //         return Ok($"User role updated to {newRole}");
        //     }
        //     else
        //     {
        //         return BadRequest("Failed to update user role");
        //     }
        // }
    }
}
