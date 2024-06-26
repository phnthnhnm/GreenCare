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
    }
}
