using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
