using GreenCare.API.Models;

namespace GreenCare.API.Interfaces
{
    public interface IPlantTypeServiceRepository
    {
        Task<List<PlantTypeService>> GetAllAsync();
        Task<List<Service>> GetServicesByPlantTypeIdAsync(int plantTypeId);
        Task<List<PlantType>> GetPlantTypesByServiceIdAsync(int serviceId);
        Task AddAsync(PlantTypeService plantTypeService);
        Task DeleteAsync(int plantTypeId, int serviceId);
    }

}
