using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs.PlantType
{
    public class AddPlantTypeDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
