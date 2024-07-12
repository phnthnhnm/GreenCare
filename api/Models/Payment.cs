using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Helpers;

namespace api.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [EnumDataType(typeof(PaymentMethod))]
        public string PaymentMethod { get; set; } = string.Empty;

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [EnumDataType(typeof(PaymentStatus))]
        public string Status { get; set; } = null;
    }
}
