using api.Models;

namespace api.Interfaces
{
    public interface IExpertServicesRepository
    {
        Task<List<Service>> GetExpertServicesAsync(ApplicationUser user);
    }
}
