namespace GreenCare.API.Models.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        // Optional: Include PlantType details if needed
        public int? PlantTypeId { get; set; }
        public string? PlantTypeName { get; set; }

        // Optional: Include Expert details if needed
        public int? ExpertId { get; set; }
        public string? ExpertName { get; set; }
    }
}
