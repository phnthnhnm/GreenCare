using api.Dtos.Service;
using api.Models;

namespace api.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceDto ToServiceDto(this Service service)
        {
            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration
            };
        }

        public static Service ToServiceFromCreateDto(this CreateServiceDto createServiceDto)
        {
            return new Service
            {
                Name = createServiceDto.Name,
                Description = createServiceDto.Description,
                Price = createServiceDto.Price,
                Duration = createServiceDto.Duration
            };
        }

        public static Service ToServiceFromUpdateDto(this UpdateServiceDto updateServiceDto)
        {
            return new Service
            {
                Name = updateServiceDto.Name,
                Description = updateServiceDto.Description,
                Price = updateServiceDto.Price,
                Duration = updateServiceDto.Duration
            };
        }
    }
}
