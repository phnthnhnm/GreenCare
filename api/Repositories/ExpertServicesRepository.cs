using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExpertServicesRepository : IExpertServicesRepository
    {
        private readonly GreenCareDbContext _context;

        public ExpertServicesRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpertService>> GetAllAsync()
        {
            return await _context.ExpertServices.ToListAsync();
        }

        public async Task<List<Service>> GetServicesByExpertAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return await _context.ExpertServices
                .Where(es => es.ExpertId == user.Id)
                .Select(es => es.Service)
                .ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetExpertsByServiceAsync(int serviceId)
        {
            return await _context.ExpertServices
                .Where(es => es.ServiceId == serviceId)
                .Select(es => es.Expert)
                .ToListAsync();
        }

        public async Task CreateAsync(ExpertService expertService)
        {
            if (expertService == null)
            {
                throw new ArgumentNullException(nameof(expertService));
            }

            if (await _context.ExpertServices.AnyAsync(pts =>
                pts.ExpertId == expertService.ExpertId &&
                pts.ServiceId == expertService.ServiceId))
            {
                throw new InvalidOperationException("This association already exists");
            }

            await _context.ExpertServices.AddAsync(expertService);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string expertId, int serviceId)
        {
            var expertService = await _context.ExpertServices.FindAsync(expertId, serviceId);

            if (expertService == null)
            {
                throw new InvalidOperationException("This association does not exist");
            }

            _context.ExpertServices.Remove(expertService);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Service>> GetServicesByExpertIdAsync(string expertId)
        {
            return await _context.ExpertServices
                .Where(es => es.ExpertId == expertId)
                .Select(es => es.Service)
                .ToListAsync();
        }
    }
}
