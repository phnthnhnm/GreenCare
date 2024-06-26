using api.Dtos.Payment;
using api.Models;

namespace api.Interfaces
{
    public interface IPaymentsRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> UpdateAsync(int id, UpdatePaymentDto paymentDto);
        Task<Payment?> DeleteAsync(int id);
    }
}
