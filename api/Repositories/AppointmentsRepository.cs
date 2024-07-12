using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Appointment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly GreenCareDbContext _context;

        public AppointmentsRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.Include(a => a.Payment).ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments.Include(a => a.Payment).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment?> UpdateAsync(int id, UpdateAppointmentDto appointmentDto)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return null;
            }

            appointment.UserId = appointmentDto.UserId;
            appointment.ExpertId = appointmentDto.ExpertId;
            appointment.DateTime = appointmentDto.DateTime;
            appointment.Status = appointmentDto.Status;

            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<Appointment?> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return null;
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId)
        {
            return await _context.Appointments.Where(a => a.UserId == userId).Include(a => a.Payment).ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByExpertIdAsync(string expertId)
        {
            return await _context.Appointments.Where(a => a.ExpertId == expertId).Include(a => a.Payment).ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByUserAsync(ApplicationUser user)
        {
            return await _context.Appointments.Where(a => a.User == user).Include(a => a.Payment).ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByExpertAsync(ApplicationUser expert)
        {
            return await _context.Appointments.Where(a => a.Expert == expert).Include(a => a.Payment).ToListAsync();
        }
    }
}
