using GreenCare.API.DTOs;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using GreenCare.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Services
{
    public class PlantTypeService : IPlantTypeService
    {
        private readonly IPlantTypeRepository _repository;

        public PlantTypeService(IPlantTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlantTypeDto>> GetAllPlantTypesAsync()
        {
            var plantTypes = await _repository.GetAllPlantTypesAsync();
            return plantTypes.Select(pt => new PlantTypeDto
            {
                Id = pt.Id,
                Name = pt.Name,
                ServiceCount = pt.Services.Count // Include service count
            });
        }

        public async Task<PlantTypeDto> GetPlantTypeByIdAsync(int id)
        {
            var plantType = await _repository.GetPlantTypeByIdAsync(id);
            return plantType != null ? new PlantTypeDto
            {
                Id = plantType.Id,
                Name = plantType.Name,
                ServiceCount = plantType.Services.Count
            } : null; // Return null if not found
        }

        public async Task<PlantTypeDto> AddPlantTypeAsync(AddPlantTypeDto plantTypeDto)
        {
            var existingPlantTypes = await _repository.GetAllPlantTypesAsync();
            if (existingPlantTypes.Any(pt => pt.Name == plantTypeDto.Name))
            {
                throw new DbUpdateException("Plant type with this name already exists.");
            }


            var newPlantType = new PlantType { Name = plantTypeDto.Name };
            await _repository.CreatePlantTypeAsync(newPlantType);

            return new PlantTypeDto // Return the created plant type
            {
                Id = newPlantType.Id,
                Name = newPlantType.Name,
                ServiceCount = 0 // New plant type, so no services yet
            };
        }

        public async Task UpdatePlantTypeAsync(int id, UpdatePlantTypeDto plantTypeDto)
        {
            var existingPlantType = await _repository.GetPlantTypeByIdAsync(id);
            if (existingPlantType == null)
            {
                throw new KeyNotFoundException("Plant type not found.");
            }

            // Check for duplicate name
            var existingPlantTypes = await _repository.GetAllPlantTypesAsync();
            if (existingPlantTypes.Any(pt =>
                pt.Name.ToLower() == plantTypeDto.Name.ToLower() && pt.Id != id))
            {
                throw new DbUpdateException("Plant type with this name already exists.");
            }


            // Update the plant type
            existingPlantType.Name = plantTypeDto.Name;
            await _repository.UpdatePlantTypeAsync(existingPlantType);
        }

        public async Task DeletePlantTypeAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                throw new KeyNotFoundException("Plant type not found.");
            }

            try
            {
                await _repository.DeletePlantTypeAsync(id);
            }
            catch (DbUpdateException ex)
            {
                // If the delete fails due to foreign key constraints, throw a more specific exception
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547) // Foreign key violation
                {
                    throw new InvalidOperationException("Cannot delete plant type due to existing dependencies.");
                }
                throw; // Re-throw if it's a different error
            }
        }
    }
}
