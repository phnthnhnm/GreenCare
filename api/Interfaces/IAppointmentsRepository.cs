using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Appointment;
using api.Models;

namespace api.Interfaces
{
    public interface IAppointmentsRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<Appointment?> UpdateAsync(int id, UpdateAppointmentDto appointmentDto);
        Task<Appointment?> DeleteAsync(int id);
        Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId);
        Task<List<Appointment>> GetAppointmentsByExpertIdAsync(string expertId);
    }
}
