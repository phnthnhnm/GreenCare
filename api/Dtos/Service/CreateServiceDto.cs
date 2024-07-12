using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Service
{
    public class CreateServiceDto
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
