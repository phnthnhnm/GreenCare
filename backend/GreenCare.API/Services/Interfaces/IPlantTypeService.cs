using GreenCare.API.DTOs.PlantType;

namespace GreenCare.API.Services.Interfaces
{
    public interface IPlantTypeService
    {
        Task<IEnumerable<PlantTypeDto>> GetAllPlantTypesAsync();
        Task<PlantTypeDto> GetPlantTypeByIdAsync(int id);
        Task<PlantTypeDto> AddPlantTypeAsync(AddPlantTypeDto plantTypeDto);
        Task UpdatePlantTypeAsync(int id, UpdatePlantTypeDto plantTypeDto);
        Task DeletePlantTypeAsync(int id);
    }

}
