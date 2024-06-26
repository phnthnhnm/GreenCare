using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Payment;
using api.Models;

namespace api.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentDto ToPaymentDto(this Payment payment)
        {
            return new PaymentDto
            {
                Id = payment.Id,
                AppointmentId = payment.AppointmentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod.ToString(),
                DateTime = payment.DateTime,
                Status = payment.Status.ToString()
            };
        }

        public static Payment ToPaymentFromCreateDto(this CreatePaymentDto createDto)
        {
            return new Payment
            {
                AppointmentId = createDto.AppointmentId,
                Amount = createDto.Amount,
                PaymentMethod = createDto.PaymentMethod,
                DateTime = createDto.DateTime,
                Status = createDto.Status
            };
        }

        public static Payment ToPaymentFromUpdateDto(this UpdatePaymentDto createDto)
        {
            return new Payment
            {
                AppointmentId = createDto.AppointmentId,
                Amount = createDto.Amount,
                PaymentMethod = createDto.PaymentMethod,
                DateTime = createDto.DateTime,
                Status = createDto.Status
            };
        }
    }
}
