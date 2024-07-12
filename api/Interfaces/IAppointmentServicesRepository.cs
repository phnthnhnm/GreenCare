using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAppointmentServicesRepository
    {
        Task<List<AppointmentService>> GetAllAsync();
        Task<List<Service>> GetServicesByAppointmentIdAsync(int appointmentId);
        Task<List<Appointment>> GetAppointmentsByServiceIdAsync(int serviceId);
        Task AddAsync(AppointmentService appointmentService);
        Task DeleteAsync(int appointmentId, int serviceId);
    }
}
