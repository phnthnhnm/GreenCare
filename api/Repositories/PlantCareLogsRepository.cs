using api.Data;
using api.Dtos.PlantCareLog;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PlantCareLogsRepository : IPlantCareLogsRepository
    {
        private readonly GreenCareDbContext _context;

        public PlantCareLogsRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlantCareLog>> GetAllAsync()
        {
            return await _context.PlantCareLogs.ToListAsync();
        }

        public async Task<PlantCareLog?> GetByIdAsync(int id)
        {
            return await _context.PlantCareLogs.FindAsync(id);
        }

        public async Task<PlantCareLog> CreateAsync(PlantCareLog plantCareLog)
        {
            _context.PlantCareLogs.Add(plantCareLog);
            await _context.SaveChangesAsync();
            return plantCareLog;
        }

        public async Task<PlantCareLog?> UpdateAsync(int id, UpdatePlantCareLogDto updateDto)
        {
            var plantCareLog = await _context.PlantCareLogs.FindAsync(id);
            if (plantCareLog == null)
            {
                return null;
            }

            plantCareLog.ExpertId = updateDto.ExpertId;
            plantCareLog.AppointmentId = updateDto.AppointmentId;
            plantCareLog.Notes = updateDto.Notes;
            plantCareLog.LogDate = updateDto.LogDate;

            await _context.SaveChangesAsync();
            return plantCareLog;
        }

        public async Task<PlantCareLog?> DeleteAsync(int id)
        {
            var plantCareLog = await _context.PlantCareLogs.FindAsync(id);
            if (plantCareLog == null)
            {
                return null;
            }

            _context.PlantCareLogs.Remove(plantCareLog);
            await _context.SaveChangesAsync();
            return plantCareLog;
        }
    }
}
