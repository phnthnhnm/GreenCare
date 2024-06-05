using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.Models.DTOs
{
    public class UpdatePlantTypeDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
