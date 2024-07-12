using api.Dtos.PlantType;
using api.Models;

namespace api.Mappers
{
    public static class PlantTypeMapper
    {
        public static PlantTypeDto ToPlantTypeDto(this PlantType plantTypeModel)
        {
            return new PlantTypeDto
            {
                Id = plantTypeModel.Id,
                Name = plantTypeModel.Name
            };
        }

        public static PlantType ToPlantTypeFromCreateDto(this CreatePlantTypeDto plantTypeDto)
        {
            return new PlantType
            {
                Name = plantTypeDto.Name
            };
        }
    }
}
