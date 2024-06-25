using GreenCare.API.Data;
using GreenCare.API.Dtos.PlantType;
using GreenCare.API.Helpers;
using GreenCare.API.Interfaces;
using GreenCare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Repositories
{
    public class PlantTypeRepository : IPlantTypeRepository
    {
        private readonly GreenCareDbContext _context;

        public PlantTypeRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<PlantType> CreateAsync(PlantType plantType)
        {
            await _context.PlantTypes.AddAsync(plantType);
            await _context.SaveChangesAsync();
            return plantType;
        }

        public async Task<PlantType?> DeleteAsync(int id)
        {
            var plantTypeModel = await _context.PlantTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (plantTypeModel == null)
            {
                return null;
            }

            _context.PlantTypes.Remove(plantTypeModel);
            await _context.SaveChangesAsync();
            return plantTypeModel;
        }

        public async Task<List<PlantType>> GetAllAsync(PlantTypeQuery query)
        {
            var plantTypes = _context.PlantTypes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                plantTypes = plantTypes.Where(pt => pt.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    plantTypes = query.IsDescending
                        ? plantTypes.OrderByDescending(pt => pt.Name)
                        : plantTypes.OrderBy(pt => pt.Name);
                }
            }

            return await plantTypes.ToListAsync();
        }

        public async Task<PlantType?> GetByIdAsync(int id)
        {
            return await _context.PlantTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlantType?> UpdateAsync(int id, UpdatePlantTypeDto plantTypeDto)
        {
            var existingPlantType = await _context.PlantTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPlantType == null)
            {
                return null;
            }

            existingPlantType.Name = plantTypeDto.Name;

            await _context.SaveChangesAsync();

            return existingPlantType;
        }
    }
}
