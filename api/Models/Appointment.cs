using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Helpers;

namespace api.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string ExpertId { get; set; }
        public virtual ApplicationUser Expert { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [EnumDataType(typeof(AppointmentStatus))]
        public string Status { get; set; } = null!;
    }
}
