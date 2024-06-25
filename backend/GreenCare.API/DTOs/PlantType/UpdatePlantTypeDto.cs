using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.Dtos.PlantType
{
    public class UpdatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
