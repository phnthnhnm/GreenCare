namespace api.Models
{
    public class ExpertService
    {
        public string ExpertId { get; set; }
        public ApplicationUser Expert { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
