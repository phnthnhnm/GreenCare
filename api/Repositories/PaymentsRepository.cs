using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Payment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly GreenCareDbContext _context;

        public PaymentsRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment?> UpdateAsync(int id, UpdatePaymentDto updateDto)
        {
            var paymentToUpdate = await _context.Payments.FindAsync(id);
            if (paymentToUpdate == null)
            {
                return null;
            }

            paymentToUpdate.AppointmentId = updateDto.AppointmentId;
            paymentToUpdate.Amount = updateDto.Amount;
            paymentToUpdate.PaymentMethod = updateDto.PaymentMethod;
            paymentToUpdate.DateTime = updateDto.DateTime;
            paymentToUpdate.Status = updateDto.Status;

            await _context.SaveChangesAsync();
            return paymentToUpdate;
        }

        public async Task<Payment?> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return null;
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
