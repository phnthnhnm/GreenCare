using GreenCare.API.Models;

namespace GreenCare.API.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int id);
        Task<Account> GetByEmailAsync(string email); // For login
        Task<bool> ExistsAsync(int id); // Helper
    }
}
