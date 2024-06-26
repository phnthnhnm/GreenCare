using api.Dtos.PlantCareLog;
using api.Models;

namespace api.Interfaces
{
    public interface IPlantCareLogsRepository
    {
        Task<List<PlantCareLog>> GetAllAsync();
        Task<PlantCareLog?> GetByIdAsync(int id);
        Task<PlantCareLog> CreateAsync(PlantCareLog plantCareLog);
        Task<PlantCareLog?> UpdateAsync(int id, UpdatePlantCareLogDto updateDto);
        Task<PlantCareLog?> DeleteAsync(int id);
    }
}
