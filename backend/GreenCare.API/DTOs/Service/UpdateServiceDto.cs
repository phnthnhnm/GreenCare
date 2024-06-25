using System.ComponentModel.DataAnnotations;

namespace GreenCare.API.Dtos.Service
{
    public class UpdateServiceDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
