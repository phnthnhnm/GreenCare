using GreenCare.API.DTOs;

namespace GreenCare.API.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceByIdAsync(int id);
        Task<ServiceDto> AddServiceAsync(AddServiceDto addServiceDto);
        Task UpdateServiceAsync(int id, UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
    }
}

