using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace api.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountsRepository(UserManager<ApplicationUser> userManager, ITokenService tokenService, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
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

            var token = await _tokenService.CreateToken(user);
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
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                return new RegisterResultDto { IsSuccessful = false, Errors = roleResult.Errors.Select(e => e.Description) };
            }
            var token = await _tokenService.CreateToken(user);
            await SendConfirmationEmail(registerDto.Email, user);
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
            if (!addResult.Succeeded)
            {
                return addResult;
            }

            // Remove old role claims
            var claims = await _userManager.GetClaimsAsync(user);
            var roleClaims = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            foreach (var claim in roleClaims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }

            // Add new role claim
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));

            return IdentityResult.Success;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> DeleteAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.DeleteAsync(user);
        }

        private async Task SendConfirmationEmail(string? email, ApplicationUser? user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"http://localhost:5062/api/accounts/confirm-email?UserId={user.Id}&Token={token}";
            await _emailService.SendEmailAsync(email, "Confirm Your Email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>;.", true);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task SendForgotPasswordEmail(string email, ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = $"http://localhost:5062/api/accounts/reset-password?Email={email}&Token={token}";
            await _emailService.SendEmailAsync(email, "Reset Your Password", $"Reset your password by <a href='{passwordResetLink}'>clicking here</a>.", true);

        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<IdentityResult> UpdateAsync(string email, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.Address = updateUserDto.Address;

            return await _userManager.UpdateAsync(user);
        }
    }
}
