using api.Dtos.PlantType;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IPlantTypeRepository
    {
        Task<List<PlantType>> GetAllAsync(PlantTypeQuery query);
        Task<PlantType?> GetByIdAsync(int id);
        Task<PlantType> CreateAsync(PlantType plantType);
        Task<PlantType?> UpdateAsync(int id, UpdatePlantTypeDto plantTypeDto);
        Task<PlantType?> DeleteAsync(int id);
    }
}
