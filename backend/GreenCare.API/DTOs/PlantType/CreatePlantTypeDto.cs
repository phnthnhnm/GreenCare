using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.Dtos.PlantType
{
    public class CreatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
