using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsRepository(UserManager<ApplicationUser> userManager, ITokenService tokenService, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new LoginResultDto
                {
                    IsSuccessful = false,
                    ErrorMessage = "Invalid email or password."
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return new LoginResultDto { IsSuccessful = false, ErrorMessage = "User account locked out." };
                }
                else
                {
                    return new LoginResultDto { IsSuccessful = false, ErrorMessage = "Invalid email or password." };
                }
            }

            var token = _tokenService.CreateToken(user);
            return new LoginResultDto { IsSuccessful = true, Email = user.Email, Token = token };
        }


        public async Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = Guid.NewGuid().ToString(),
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return new RegisterResultDto { IsSuccessful = false, Errors = result.Errors.Select(e => e.Description) };
            }

            var token = _tokenService.CreateToken(user);
            return new RegisterResultDto { IsSuccessful = true, Email = user.Email, Token = token };
        }

        public async Task<IdentityResult> ChangeRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

                if (!removeResult.Succeeded)
                {
                    return removeResult;
                }
            }

            var addResult = await _userManager.AddToRoleAsync(user, role);
            return addResult;
        }

    }
}
