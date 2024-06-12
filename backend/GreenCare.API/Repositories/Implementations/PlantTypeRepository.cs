using GreenCare.API.Data;
using GreenCare.API.Models;
using GreenCare.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Repositories.Implementations
{
    public class PlantTypeRepository : IPlantTypeRepository
    {
        private readonly GreenCareDbContext _context;

        public PlantTypeRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlantType>> GetAllPlantTypesAsync()
        {
            return await _context.PlantTypes.Include(pt => pt.Services).ToListAsync();
        }

        public async Task<PlantType> GetPlantTypeByIdAsync(int id)
        {
            return await _context.PlantTypes.Include(pt => pt.Services).FirstOrDefaultAsync(pt => pt.Id == id);
        }

        public async Task CreatePlantTypeAsync(PlantType plantType)
        {
            _context.PlantTypes.Add(plantType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlantTypeAsync(PlantType plantType)
        {
            _context.Entry(plantType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlantTypeAsync(int id)
        {
            var plantType = await _context.PlantTypes.FindAsync(id);
            if (plantType != null)
            {
                _context.PlantTypes.Remove(plantType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PlantTypes.AnyAsync(e => e.Id == id);
        }
    }
}
