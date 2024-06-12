using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs
{
    public class UpdatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
