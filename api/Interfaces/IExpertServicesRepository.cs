using api.Models;

namespace api.Interfaces
{
    public interface IExpertServicesRepository
    {
        Task<List<ExpertService>> GetAllAsync();
        Task<List<Service>> GetServicesByExpertAsync(ApplicationUser user);
    }
}
