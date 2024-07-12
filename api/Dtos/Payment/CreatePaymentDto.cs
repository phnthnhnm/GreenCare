using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;

namespace api.Dtos.Payment
{
    public class CreatePaymentDto
    {
        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        [EnumDataType(typeof(PaymentMethod))]
        public string PaymentMethod { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }

        [EnumDataType(typeof(PaymentStatus))]
        public string Status { get; set; } = null;
    }
}
