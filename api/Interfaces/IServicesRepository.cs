using api.Dtos.Service;
using api.Models;

namespace api.Interfaces
{
    public interface IServicesRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(int id);
        Task<Service> CreateAsync(Service service);
        Task<Service?> UpdateAsync(int id, UpdateServiceDto serviceDto);
        Task<Service?> DeleteAsync(int id);
    }
}
