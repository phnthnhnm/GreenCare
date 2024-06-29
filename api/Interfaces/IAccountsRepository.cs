using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginResultDto> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> ChangeRoleAsync(string email, string role);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> DeleteAsync(string email);
        Task<IdentityResult> ConfirmEmailAsync(string email, string token);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string password);
        Task<IdentityResult> UpdateAsync(string email, UpdateUserDto updateUserDto);
        Task<string> GetUserRoleAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<IdentityResult> LockUserAsync(string email);
        Task<IdentityResult> UnlockUserAsync(string email);
        Task<string> GetUserIdByEmailAsync(string email);
        Task<string> GetUserEmailByIdAsync(string id);
    }
}
