using System.ComponentModel.DataAnnotations;

namespace api.Dtos.PlantType
{
    public class UpdatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
