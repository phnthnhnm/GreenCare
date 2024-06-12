namespace GreenCare.API.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? PlantTypeId { get; set; }
        public string? PlantTypeName { get; set; }
        public int? ExpertId { get; set; }
        public string? ExpertName { get; set; }
    }
}
