using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.DTOs
{
    public class UpdateServiceDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int PlantTypeId { get; set; }
        public int? ExpertId { get; set; }
    }
}
