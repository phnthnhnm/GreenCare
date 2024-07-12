using api.Models;

namespace api.Interfaces
{
    public interface IPlantTypeServicesRepository
    {
        Task<List<PlantTypeService>> GetAllAsync();
        Task<List<Service>> GetServicesByPlantTypeIdAsync(int plantTypeId);
        Task<List<PlantType>> GetPlantTypesByServiceIdAsync(int serviceId);
        Task AddAsync(PlantTypeService plantTypeService);
        Task DeleteAsync(int plantTypeId, int serviceId);
    }

}
