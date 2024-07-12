using api.Data;
using api.Dtos.Service;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly GreenCareDbContext _context;

        public ServicesRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Service> CreateAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service?> UpdateAsync(int id, UpdateServiceDto serviceDto)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
            {
                return null;
            }

            service.Name = serviceDto.Name;
            service.Description = serviceDto.Description;
            service.Price = serviceDto.Price;
            service.Duration = serviceDto.Duration;

            await _context.SaveChangesAsync();

            return service;
        }

        public async Task<Service?> DeleteAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
            {
                return null;
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return service;
        }
    }
}
