
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.PlantCareLog
{
    public class UpdatePlantCareLogDto
    {
        public string ExpertId { get; set; }

        public int AppointmentId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Notes { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LogDate { get; set; }
    }
}
