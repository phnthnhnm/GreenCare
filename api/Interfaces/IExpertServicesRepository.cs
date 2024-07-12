using api.Models;

namespace api.Interfaces
{
    public interface IExpertServicesRepository
    {
        Task<List<ExpertService>> GetAllAsync();
        Task<List<Service>> GetServicesByExpertAsync(ApplicationUser user);
        Task<List<Service>> GetServicesByExpertIdAsync(string expertId);
        Task<List<ApplicationUser>> GetExpertsByServiceAsync(int serviceId);
        Task CreateAsync(ExpertService expertService);
        Task DeleteAsync(string expertId, int serviceId);
    }
}
