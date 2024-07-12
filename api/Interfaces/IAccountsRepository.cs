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
        Task<IdentityResult> ChangeRoleAsync(string id, string role);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> DeleteAsync(string id);
        Task<IdentityResult> ConfirmEmailAsync(string email, string token);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string password);
        Task<IdentityResult> UpdateAsync(string id, UpdateUserDto updateUserDto);
        Task<string> GetUserRoleAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<IdentityResult> LockUserAsync(string id);
        Task<IdentityResult> UnlockUserAsync(string id);
        Task<string> GetUserIdByEmailAsync(string email);
        Task<string> GetUserEmailByIdAsync(string id);
    }
}
