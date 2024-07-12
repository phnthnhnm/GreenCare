using System.ComponentModel.DataAnnotations;

namespace api.Dtos.PlantType
{
    public class CreatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
