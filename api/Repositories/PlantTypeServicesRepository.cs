using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PlantTypeServicesRepository : IPlantTypeServicesRepository
    {
        private readonly GreenCareDbContext _context;

        public PlantTypeServicesRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlantTypeService>> GetAllAsync()
        {
            return await _context.PlantTypeServices.ToListAsync();
        }

        public async Task<List<Service>> GetServicesByPlantTypeIdAsync(int plantTypeId)
        {
            var services = await _context.PlantTypeServices
                .Where(pts => pts.PlantTypeId == plantTypeId)
                .Select(pts => pts.Service)
                .ToListAsync();

            return services;
        }

        public async Task<List<PlantType>> GetPlantTypesByServiceIdAsync(int serviceId)
        {
            var plantTypes = await _context.PlantTypeServices
                .Where(pts => pts.ServiceId == serviceId)
                .Select(pts => pts.PlantType)
                .ToListAsync();

            return plantTypes;
        }

        public async Task AddAsync(PlantTypeService plantTypeService)
        {
            if (plantTypeService == null)
            {
                throw new ArgumentNullException(nameof(plantTypeService));
            }

            if (await _context.PlantTypeServices.AnyAsync(pts =>
                pts.PlantTypeId == plantTypeService.PlantTypeId &&
                pts.ServiceId == plantTypeService.ServiceId))
            {
                throw new InvalidOperationException("This association already exists");
            }

            await _context.PlantTypeServices.AddAsync(plantTypeService);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int plantTypeId, int serviceId)
        {
            var plantTypeService = await _context.PlantTypeServices.FindAsync(plantTypeId, serviceId);

            if (plantTypeService == null)
            {
                throw new ArgumentException("The specified PlantTypeService does not exist.");
            }

            _context.PlantTypeServices.Remove(plantTypeService);
            await _context.SaveChangesAsync();
        }
    }
}
