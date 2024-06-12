using GreenCare.API.DTOs.Account;

namespace GreenCare.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
        Task<AccountDto> GetAccountByIdAsync(int id);
        Task<AccountDto> LoginAsync(LoginRequestDto loginRequest);
        Task<AccountDto> RegisterAsync(RegisterRequestDto registerRequest);
        Task UpdateAccountAsync(int id, UpdateAccountDto updateDto);
        Task DeleteAccountAsync(int id);
    }
}
