using GreenCare.API.Models;

namespace GreenCare.API.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task CreateServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
        Task<bool> ExistsAsync(int id); // Helper method
        Task<bool> ServiceNameExistsAsync(string name, int excludeId = 0); // Helper method
    }
}
