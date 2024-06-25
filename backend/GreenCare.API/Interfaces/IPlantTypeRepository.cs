using GreenCare.API.Dtos.PlantType;
using GreenCare.API.Helpers;
using GreenCare.API.Models;

namespace GreenCare.API.Interfaces
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
