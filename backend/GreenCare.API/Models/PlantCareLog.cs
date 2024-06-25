namespace GreenCare.API.Models
{
    public class PlantCareLog
    {
        public int Id { get; set; }

        public int ExpertId { get; set; }

        public int AppointmentId { get; set; }

        public string? Notes { get; set; }

        public DateTime LogDate { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual ApplicationUser Expert { get; set; } = null!;
    }
}
