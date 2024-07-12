using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class PlantCareLog
    {
        public int Id { get; set; }

        public string ExpertId { get; set; }
        public virtual ApplicationUser Expert { get; set; } = null!;

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; } = null!;

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Notes { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LogDate { get; set; }
    }
}
