using GreenCare.API.DTOs;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using GreenCare.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;

        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            var services = await _repository.GetAllServicesAsync();
            return services.Select(ServiceToDto);
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _repository.GetServiceByIdAsync(id);
            return service != null ? ServiceToDto(service) : null;
        }

        public async Task<ServiceDto> AddServiceAsync(AddServiceDto addServiceDto)
        {
            if (await _repository.ServiceNameExistsAsync(addServiceDto.Name))
            {
                throw new DbUpdateException("Service with this name already exists.");
            }

            var newService = new Service
            {
                Name = addServiceDto.Name,
                Description = addServiceDto.Description,
                Price = addServiceDto.Price,
                PlantTypeId = addServiceDto.PlantTypeId,
                ExpertId = addServiceDto.ExpertId
            };

            await _repository.CreateServiceAsync(newService);
            return ServiceToDto(newService); // Return the created service
        }

        public async Task UpdateServiceAsync(int id, UpdateServiceDto updateServiceDto)
        {
            var existingService = await _repository.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                throw new KeyNotFoundException("Service not found.");
            }

            // Check for duplicate name
            if (await _repository.ServiceNameExistsAsync(updateServiceDto.Name, id)) // Exclude current ID
            {
                throw new DbUpdateException("Service with this name already exists.");
            }

            // Update the service properties
            existingService.Name = updateServiceDto.Name;
            existingService.Description = updateServiceDto.Description;
            existingService.Price = updateServiceDto.Price;
            existingService.PlantTypeId = updateServiceDto.PlantTypeId;
            existingService.ExpertId = updateServiceDto.ExpertId;

            await _repository.UpdateServiceAsync(existingService);
        }

        public async Task DeleteServiceAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                throw new KeyNotFoundException("Service not found.");
            }

            try
            {
                await _repository.DeleteServiceAsync(id);
            }
            catch (DbUpdateException ex)
            {
                // Check for foreign key constraint violation
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    throw new InvalidOperationException("Cannot delete service due to existing dependencies.");
                }
                throw; // Re-throw if it's another error
            }
        }

        private static ServiceDto ServiceToDto(Service service)
        {
            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                PlantTypeId = service.PlantTypeId,
                PlantTypeName = service.PlantType?.Name, // Use null-conditional operator to handle potential null
                ExpertId = service.ExpertId,
                ExpertName = service.Expert?.Name
            };
        }
    }
}
