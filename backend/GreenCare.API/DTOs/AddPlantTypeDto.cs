using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs
{
    public class AddPlantTypeDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
