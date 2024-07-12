using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Appointment;
using api.Models;

namespace api.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto ToAppointmentDto(this Appointment appointmentModel)
        {
            return new AppointmentDto
            {
                Id = appointmentModel.Id,
                UserId = appointmentModel.UserId,
                ExpertId = appointmentModel.ExpertId,
                DateTime = appointmentModel.DateTime,
                Status = appointmentModel.Status,
                Payment = appointmentModel.Payment?.ToPaymentDto()
            };
        }

        public static Appointment ToAppointmentFromCreateDto(this CreateAppointmentDto createAppointmentDto)
        {
            return new Appointment
            {
                UserId = createAppointmentDto.UserId,
                ExpertId = createAppointmentDto.ExpertId,
                DateTime = createAppointmentDto.DateTime,
                Status = createAppointmentDto.Status
            };
        }

        public static Appointment ToAppointmentFromUpdateDto(this UpdateAppointmentDto updateAppointmentDto)
        {
            return new Appointment
            {
                UserId = updateAppointmentDto.UserId,
                ExpertId = updateAppointmentDto.ExpertId,
                DateTime = updateAppointmentDto.DateTime,
                Status = updateAppointmentDto.Status
            };
        }
    }
}
