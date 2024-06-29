using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces
{
    public interface IAccountsRepository
    {
        Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginResultDto> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> ChangeRoleAsync(string id, string role);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> DeleteAsync(string id);
    }
}
