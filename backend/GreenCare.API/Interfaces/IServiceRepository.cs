using GreenCare.API.Dtos.Service;
using GreenCare.API.Models;

namespace GreenCare.API.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(int id);
        Task<Service> CreateAsync(Service service);
        Task<Service?> UpdateAsync(int id, UpdateServiceDto serviceDto);
        Task<Service?> DeleteAsync(int id);
    }
}
