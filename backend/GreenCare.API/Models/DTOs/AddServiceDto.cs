namespace GreenCare.API.Models.DTOs
{
    public class AddServiceDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int? PlantTypeId { get; set; }

        public int? ExpertId { get; set; }
    }
}
