using GreenCare.API.DTOs.Account;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using GreenCare.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        // Add other dependencies like email service or password hasher if needed

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _repository.GetAllAccountsAsync();
            return accounts.Select(account => AccountToDto(account)); // Map to DTOs
        }

        public async Task<AccountDto> GetAccountByIdAsync(int id)
        {
            var account = await _repository.GetAccountByIdAsync(id);
            return account != null ? AccountToDto(account) : null; // Map to DTO (or null)
        }

        public async Task<AccountDto> LoginAsync(LoginRequestDto loginRequest)
        {
            var account = await _repository.GetByEmailAsync(loginRequest.Email);
            // In production, you MUST hash the password for comparison!
            if (account == null || account.Password != loginRequest.Password)
            {
                return null; // Invalid credentials
            }
            return AccountToDto(account);
        }

        public async Task<AccountDto> RegisterAsync(RegisterRequestDto registerRequest)
        {
            if (await _repository.GetByEmailAsync(registerRequest.Email) != null)
            {
                throw new DbUpdateException("Account with this email already exists.");
            }

            var newAccount = new Account
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password, // Insecure, replace with password hashing
                Role = registerRequest.Role,
                Name = registerRequest.Name,
                Phone = registerRequest.Phone,
                Address = registerRequest.Address
            };

            await _repository.CreateAccountAsync(newAccount);
            return AccountToDto(newAccount);
        }

        public async Task UpdateAccountAsync(int id, UpdateAccountDto updateDto)
        {
            var existingAccount = await _repository.GetAccountByIdAsync(id);

            if (existingAccount == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }

            // Update properties
            existingAccount.Name = updateDto.Name;
            existingAccount.Email = updateDto.Email;
            existingAccount.Phone = updateDto.Phone;
            existingAccount.Address = updateDto.Address;
            if (!string.IsNullOrEmpty(updateDto.Role))
            {
                existingAccount.Role = updateDto.Role;
            }
            // Handle password change (In production, hash the new password)
            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                existingAccount.Password = updateDto.Password; // Insecure, for example only
            }

            // Check for email uniqueness
            if (await _repository.GetByEmailAsync(updateDto.Email) != null && existingAccount.Id != id)
            {
                throw new DbUpdateException("Account with this email already exists.");
            }

            await _repository.UpdateAccountAsync(existingAccount);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _repository.GetAccountByIdAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            if (account.Role == "admin")
            {
                throw new InvalidOperationException("Cannot delete an admin account.");
            }

            // Check for related data (optional, but good practice)
            if (account.AppointmentCustomers.Any() || account.AppointmentExperts.Any() ||
                account.PlantCareLogs.Any() || account.Reviews.Any() || account.Services.Any())
            {
                throw new InvalidOperationException("Cannot delete account with associated data.");
            }
            await _repository.DeleteAccountAsync(id);
        }


        private static AccountDto AccountToDto(Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                Email = account.Email,
                Role = account.Role,
                Name = account.Name,
                Phone = account.Phone,
                Address = account.Address,
                AppointmentsAsCustomerCount = account.AppointmentCustomers.Count,
                AppointmentsAsExpertCount = account.AppointmentExperts.Count,
                PlantCareLogCount = account.PlantCareLogs.Count,
                ReviewCount = account.Reviews.Count,
                ServiceCount = account.Services.Count
            };
        }
    }
}
