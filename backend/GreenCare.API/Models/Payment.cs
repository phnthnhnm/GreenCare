using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenCare.API.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public DateTime PaymentDateTime { get; set; }

        [Required]
        public string Status { get; set; } = "pending";

        public virtual Appointment Appointment { get; set; } = null!;
    }
}
