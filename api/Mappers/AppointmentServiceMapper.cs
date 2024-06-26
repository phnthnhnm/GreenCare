using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.AppointmentService;
using api.Models;

namespace api.Mappers
{
    public static class AppointmentServiceMapper
    {
        public static AppointmentServiceDto ToAppointmentServiceDto(this AppointmentService appointmentService)
        {
            return new AppointmentServiceDto
            {
                AppointmentId = appointmentService.AppointmentId,
                ServiceId = appointmentService.ServiceId
            };
        }

        public static AppointmentService ToAppointmentServiceFromCreateDto(this CreateAppointmentServiceDto createAppointmentServiceDto)
        {
            return new AppointmentService
            {
                AppointmentId = createAppointmentServiceDto.AppointmentId,
                ServiceId = createAppointmentServiceDto.ServiceId
            };
        }
    }
}
