using api.Dtos.Account;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces
{
    public interface IAccountsRepository
    {
        Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginResultDto> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> ChangeRoleAsync(string id, string role);
    }
}
