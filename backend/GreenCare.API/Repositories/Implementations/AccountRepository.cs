using GreenCare.API.Data;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GreenCareDbContext _context;

        public AccountRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            // Eager loading to avoid N+1 problem
            return await _context.Accounts
                .Include(a => a.AppointmentCustomers)
                .Include(a => a.AppointmentExperts)
                .Include(a => a.PlantCareLogs)
                .Include(a => a.Reviews)
                .Include(a => a.Services)
                .ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts
                .Include(a => a.AppointmentCustomers)
                .Include(a => a.AppointmentExperts)
                .Include(a => a.PlantCareLogs)
                .Include(a => a.Reviews)
                .Include(a => a.Services)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Accounts.AnyAsync(e => e.Id == id);
        }
    }
}
