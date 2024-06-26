using api.Dtos.PlantTypeService;
using api.Models;

namespace api.Mappers
{
    public static class PlantTypeServiceMapper
    {
        public static PlantTypeServiceDto ToPlantTypeServiceDto(this PlantTypeService plantTypeService)
        {
            return new PlantTypeServiceDto
            {
                PlantTypeId = plantTypeService.PlantTypeId,
                ServiceId = plantTypeService.ServiceId
            };
        }

        public static PlantTypeService ToPlantTypeServiceFromCreateDto(this CreatePlantTypeServiceDto createDto)
        {
            return new PlantTypeService
            {
                PlantTypeId = createDto.PlantTypeId,
                ServiceId = createDto.ServiceId
            };
        }
    }
}
