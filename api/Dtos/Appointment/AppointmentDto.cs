using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Helpers;

namespace api.Dtos.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ExpertId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [EnumDataType(typeof(AppointmentStatus))]
        public string Status { get; set; } = null!;
    }
}
