using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.AppointmentService
{
    public class CreateAppointmentServiceDto
    {
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
    }
}
