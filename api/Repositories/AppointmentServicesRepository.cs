using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class AppointmentServicesRepository : IAppointmentServicesRepository
    {
        private readonly GreenCareDbContext _context;

        public AppointmentServicesRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentService>> GetAllAsync()
        {
            return await _context.AppointmentServices.ToListAsync();
        }

        public async Task<List<Service>> GetServicesByAppointmentIdAsync(int appointmentId)
        {
            return await _context.AppointmentServices
                .Where(aps => aps.AppointmentId == appointmentId)
                .Select(aps => aps.Service)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByServiceIdAsync(int serviceId)
        {
            return await _context.AppointmentServices
                .Where(aps => aps.ServiceId == serviceId)
                .Select(aps => aps.Appointment)
                .ToListAsync();
        }

        public async Task AddAsync(AppointmentService appointmentService)
        {
            if (appointmentService == null)
            {
                throw new ArgumentNullException(nameof(appointmentService));
            }

            if (await _context.AppointmentServices.AnyAsync(aps =>
                aps.AppointmentId == appointmentService.AppointmentId &&
                aps.ServiceId == appointmentService.ServiceId))
            {
                throw new InvalidOperationException("This association already exists");
            }
            await _context.AppointmentServices.AddAsync(appointmentService);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int appointmentId, int serviceId)
        {
            var appointmentService = await _context.AppointmentServices
                .FirstOrDefaultAsync(aps => aps.AppointmentId == appointmentId && aps.ServiceId == serviceId);

            if (appointmentService == null)
            {
                throw new InvalidOperationException("This association does not exist");
            }

            _context.AppointmentServices.Remove(appointmentService);
            await _context.SaveChangesAsync();
        }
    }
}
