using GreenCare.API.Models;

namespace GreenCare.API.Repositories.Interfaces
{
    public interface IPlantTypeRepository
    {
        Task<IEnumerable<PlantType>> GetAllPlantTypesAsync();
        Task<PlantType> GetPlantTypeByIdAsync(int id);
        Task CreatePlantTypeAsync(PlantType plantType);
        Task UpdatePlantTypeAsync(PlantType plantType);
        Task DeletePlantTypeAsync(int id);
        Task<bool> ExistsAsync(int id); // Helper method
    }
}
