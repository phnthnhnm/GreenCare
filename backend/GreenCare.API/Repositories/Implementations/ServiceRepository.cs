using GreenCare.API.Data;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Repositories.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly GreenCareDbContext _context;

        public ServiceRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.Include(s => s.PlantType).Include(s => s.Expert).ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.Include(s => s.PlantType).Include(s => s.Expert).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateServiceAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Services.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> ServiceNameExistsAsync(string name, int excludeId = 0)
        {
            return await _context.Services
                .AnyAsync(s => s.Name.ToLower() == name.ToLower() && s.Id != excludeId);
        }
    }
}
